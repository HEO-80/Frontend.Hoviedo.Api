using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hoviedo.Api.Blog.Model
{
    public class DbContext
    {
        public  static List<Post> ListaPost { get; set; }

        public static void InitialLoad()
        {
            ListaPost = new List<Post>();


            ListaPost.Add(new Post { Id = 0, Title = "REality", Body = "Estado en el que te encuentras de manera normla" });
            ListaPost.Add(new Post { Id = 1, Title = "Espiritual", Body = "Estado en el que tus sentidos estan alerta" });
            ListaPost.Add(new Post { Id = 2, Title = "Ficcion", Body = "Momento en el que puedes visualizar con barras" });
            ListaPost.Add(new Post { Id = 3, Title = "Sueño", Body = "Zona en la que el mundo lo tienes como trascendental" });
            ListaPost.Add(new Post { Id = 4, Title = "Impression", Body = "Hacer que el mundo cambie sin darnos cuenta" });
            ListaPost.Add(new Post { Id = 5, Title = "Surrealist", Body = "no entender la complegidad del universo" });

        }
     }
}
