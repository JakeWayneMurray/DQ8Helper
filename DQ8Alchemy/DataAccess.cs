using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Media.Imaging;
using System.IO;

namespace DQ8Alchemy
{
    public class DataAccess
    {
        public List<Category> Alchemy { get; set; }
        public List<Monster> Monsters { get; set; }

        public DataAccess()
        {
            Alchemy = JsonReader.readAlchemyFile("Recipes.json");
            Monsters = JsonReader.readMonsterFile("monsters.json");
        }

        public List<Recipe> getRecipes()
        {
            List<Recipe> recipes = new();
            foreach (Category c in Alchemy)
            {
                foreach (Recipe r in c.Recipes)
                {
                    recipes.Add(r);
                }
            }
            return recipes;
        }

        public List<Monster> getMonsters()
        {
            return Monsters;
        }

        public static ImageSource ToImageSource(System.Drawing.Image image, ImageFormat imageFormat)
        {
            BitmapImage bitmap = new BitmapImage();

            using (MemoryStream stream = new MemoryStream())
            {
                // Save to the stream
                image.Save(stream, imageFormat);

                // Rewind the stream
                stream.Seek(0, SeekOrigin.Begin);

                // Tell the WPF BitmapImage to use this stream
                bitmap.BeginInit();
                bitmap.StreamSource = stream;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
            }

            return bitmap;
        }

        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
}
