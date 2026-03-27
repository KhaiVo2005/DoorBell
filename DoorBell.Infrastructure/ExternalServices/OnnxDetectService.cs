using DoorBell.Application.Interfaces;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace DoorBell.Infrastructure.ExternalServices
{
    public class OnnxDetectService : IDetectPersonService
    {
        private readonly InferenceSession _session;

        public OnnxDetectService()
        {
            var modelPath = Path.Combine(
                AppContext.BaseDirectory,
                "Models",
                "yolov8n.onnx"
            );

            Console.WriteLine($"Loading model from: {modelPath}");

            _session = new InferenceSession(modelPath);

            Console.WriteLine("Model input name: " + _session.InputMetadata.Keys.First());
        }

        public bool HasPerson(byte[] imageBytes)
        {
            var input = Preprocess(imageBytes);

            var inputs = new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("images", input)
            };

            using var results = _session.Run(inputs);
            var output = results.First().AsTensor<float>();

            return ParseOutput(output);
        }

        private DenseTensor<float> Preprocess(byte[] imageBytes)
        {
            int size = 640;

            using var image = Image.Load<Rgb24>(imageBytes);

            // 🔥 Letterbox giữ tỉ lệ (IMPORTANT)
            image.Mutate(x =>
            {
                x.Resize(new ResizeOptions
                {
                    Size = new Size(size, size),
                    Mode = ResizeMode.Pad,
                    PadColor = Color.Black
                });
            });

            var tensor = new DenseTensor<float>(new[] { 1, 3, size, size });

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    var pixel = image[x, y];

                    // 🔥 FIX: RGB → BGR
                    tensor[0, 0, y, x] = pixel.B / 255f;
                    tensor[0, 1, y, x] = pixel.G / 255f;
                    tensor[0, 2, y, x] = pixel.R / 255f;
                }
            }

            return tensor;
        }

        private bool ParseOutput(Tensor<float> output)
        {
            int numBoxes = output.Dimensions[2]; // 8400

            for (int i = 0; i < numBoxes; i++)
            {
                // Lấy trực tiếp xác suất của class 0 (Person)
                float personScore = output[0, 4, i];

                // Nếu điểm tự tin lớn hơn 40% (bạn có thể chỉnh 0.3f hoặc 0.5f tùy ý)
                if (personScore > 0.3f)
                {
                    Console.WriteLine($"✅ PERSON detected with confidence: {personScore * 100}%");
                    return true;
                }
            }

            Console.WriteLine("❌ No person detected with confidence: {personScore * 100}%");
            return false;
        }
    }
}