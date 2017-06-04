using Microsoft.ProjectOxford.Emotion;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EmocionesApp.Clases

{

	public class ServicioEmociones

	{

		static string key = "f7dfb96b615e4341ab151b0a092488d8";

        public static async Task<Dictionary<string, float>> ObtenerEmociones(Stream stream)

		{

			EmotionServiceClient cliente = new EmotionServiceClient(key);
			var emociones = await cliente.RecognizeAsync(stream);

			if (emociones == null || emociones.Count() == 0)
                return null;


			return emociones[0].Scores.ToRankedList().ToDictionary(x => x.Key, x => x.Value);   

		}

	}

}