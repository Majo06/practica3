using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bebida[] bebida = new Bebida[2];
            Empleado empleado = new Empleado("Arturo", 22, "Masculino");
            Cliente cliente = new Cliente();

            bebida[0] = new SinAlcohol("Piña colada (sin alcohol)", "Delicioso coctel de piña con coco SIN ALOCHOL", "Jugo de piña, crema de coco, hielo, trozos de piña");
            bebida[1] = new ConAlcohol("Piña colada", "Delicioso coctel de piña con coco CON ALOCHOL", "Ron blanco ,jugo de piña, crema de coco, hielo, trozos de piña");

            Console.WriteLine(empleado.saludar());
            Console.WriteLine("Nombre: ");
            cliente.nombre = Console.ReadLine();
            Console.WriteLine("Edad: ");
            cliente.edad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Genero: M o F");
            cliente.sexo = Console.ReadLine();

            Console.WriteLine("Bienvenido " + cliente.nombre + " que desea beber?");
            for (int i = 0; i < bebida.Length; i++)
            {
                Console.WriteLine(i + "- " + bebida[i].nombre);
            }
            int dec = Convert.ToInt32(Console.ReadLine());
            if (dec == 0)
            {
                Console.Clear();
                Console.WriteLine(empleado.nombre + "Empezara a preparar la bebida...");
                Console.WriteLine(empleado.preparar(bebida[0]));
            }
            if (dec == 1)
            {
                if (cliente.edad < 18)
                {
                    Console.WriteLine("No puede ingerir bebidas alcoholicas porque es menor de edad");
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine(empleado.nombre + "Empieza a preparar la bebida...");
                    Console.WriteLine(empleado.preparar(bebida[0]));
                }
            }
            Console.WriteLine(cliente.despedirse());


            Console.ReadLine();

        }
        public abstract class Bebida
        {
            public abstract string nombre { get; set; }
            public abstract string descripcion { get; set; }
            public abstract string ingredientes { get; set; }
        }
        public class ConAlcohol : Bebida
        {
            public override string nombre { get; set; }
            public override string descripcion { get; set; }
            public override string ingredientes { get; set; }

            public ConAlcohol(string Nombre, string Descripcion, string Ingredientes)
            {
                this.nombre = Nombre;
                this.descripcion = Descripcion;
                this.ingredientes = Ingredientes;
            }
        }
        public class SinAlcohol : Bebida
        {
            public override string nombre { get; set; }
            public override string descripcion { get; set; }
            public override string ingredientes { get; set; }
            public SinAlcohol(string Nombre, string Descripcion, string Ingredientes)
            {
                this.nombre = Nombre;
                this.descripcion = Descripcion;
                this.ingredientes = Ingredientes;
            }
        }
        public interface iPersona
        {
            string nombre { get; set; }
            int edad { get; set; }
            string sexo { get; set; }
            string saludar();
            string despedirse();
        }

        class Cliente : iPersona
        {
            public string nombre { get; set; }
            public int edad { get; set; }
            public string sexo { get; set; }

            public string despedirse()
            {
                return this.nombre + " gracias por visitarnos, adios";
            }

            public string saludar()
            {
                return "Hola mi nombre es. " + this.nombre;
            }
        }

        class Empleado : iPersona
        {
            public string nombre { get; set; }
            public int edad { get; set; }
            public string sexo { get; set; }
            public Empleado(string Nombre, int Edad, string sexo)
            {
                this.nombre = Nombre;
                this.edad = Edad;
                this.sexo = sexo;
            }

            public string saludar()
            {
                return "Hola! bienvenido mi nombre es " + this.nombre + ", me da su nombre y edad";
            }

            public string preparar(Bebida bebida)
            {
                string resultado = "Vierte " + bebida.ingredientes + " sobre la vatidora y vate por 30 segundos";
                return resultado;
            }

            public string despedirse()
            {
                return this.nombre + "- Vuelva pronto";
            }
        }
    }
}
