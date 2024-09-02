using System;
using System.Collections.Generic;

namespace ToDoList
{
    /// <summary>
    /// Clase principal que contiene la lógica del programa.
    /// </summary>
    class Program
    {
        // Lista para almacenar las tareas creadas.
        static List<Tarea> tareas = new List<Tarea>();

        /// <summary>
        /// Método principal que se ejecuta al iniciar el programa.
        /// Contiene un bucle para mostrar el menú de opciones al usuario.
        /// </summary>
        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                // Limpia la consola y muestra el menú de opciones.
                Console.Clear();
                Console.WriteLine("Menú de Tareas");
                Console.WriteLine("1. Agregar tarea");
                Console.WriteLine("2. Listar tareas");
                Console.WriteLine("3. Marcar como completada");
                Console.WriteLine("4. Eliminar tarea");
                Console.WriteLine("5. Salir");
                Console.Write("Selecciona una opción: ");

                // Lee la opción seleccionada por el usuario.
                int opcion;
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    // Ejecuta la acción correspondiente según la opción seleccionada.
                    switch (opcion)
                    {
                        case 1:
                            AgregarTarea();
                            break;
                        case 2:
                            ListarTareas();
                            break;
                        case 3:
                            MarcarCompletada();
                            break;
                        case 4:
                            EliminarTarea();
                            break;
                        case 5:
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Opción inválida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida.");
                }

                Console.WriteLine();
                Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Clase que representa una tarea en la lista de tareas.
        /// </summary>
        class Tarea
        {
            /// <summary>
            /// Descripción de la tarea.
            /// </summary>
            public string Descripcion { get; set; }

            /// <summary>
            /// Fecha límite para completar la tarea (opcional).
            /// </summary>
            public DateTime? FechaLimite { get; set; }

            /// <summary>
            /// Indica si la tarea ha sido completada.
            /// </summary>
            public bool Completada { get; set; }
        }

        /// <summary>
        /// Método que permite al usuario agregar una nueva tarea.
        /// Solicita la descripción y la fecha límite (opcional) de la tarea.
        /// </summary>
        static void AgregarTarea()
        {
            Console.Write("Ingrese la descripción de la tarea: ");
            string descripcion = Console.ReadLine();

            Console.Write("Ingrese la fecha límite (opcional, formato dd/MM/yyyy): ");
            string fechaLimiteStr = Console.ReadLine();
            DateTime fechaLimite;

            // Si se ingresa una fecha válida, se asigna; de lo contrario, se deja sin fecha límite.
            if (DateTime.TryParse(fechaLimiteStr, out fechaLimite))
            {
                tareas.Add(new Tarea { Descripcion = descripcion, FechaLimite = fechaLimite });
            }
            else
            {
                tareas.Add(new Tarea { Descripcion = descripcion });
            }

            Console.WriteLine("Tarea agregada.");
        }

        /// <summary>
        /// Método que lista todas las tareas registradas.
        /// Muestra la descripción, fecha límite (si existe) y estado de completado.
        /// </summary>
        static void ListarTareas()
        {
            if (tareas.Count == 0)
            {
                Console.WriteLine("No hay tareas registradas.");
            }
            else
            {
                Console.WriteLine("Lista de tareas:");
                for (int i = 0; i < tareas.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {tareas[i].Descripcion} {(tareas[i].FechaLimite.HasValue ? $" - Fecha límite: {tareas[i].FechaLimite.Value:dd/MM/yyyy}" : "")} {(tareas[i].Completada ? " (Completada)" : "")}");
                }
            }
        }

        /// <summary>
        /// Método que permite marcar una tarea como completada.
        /// Solicita el número de tarea y la marca como completada si el número es válido.
        /// </summary>
        static void MarcarCompletada()
        {
            ListarTareas();

            Console.Write("Ingrese el número de la tarea a marcar como completada: ");
            if (int.TryParse(Console.ReadLine(), out int indice) && indice >= 1 && indice <= tareas.Count)
            {
                tareas[indice - 1].Completada = true;
                Console.WriteLine("Tarea marcada como completada.");
            }
            else
            {
                Console.WriteLine("Número de tarea inválido.");
            }
        }

        /// <summary>
        /// Método que permite eliminar una tarea de la lista.
        /// Solicita el número de tarea y la elimina si el número es válido.
        /// </summary>
        static void EliminarTarea()
        {
            ListarTareas();

            Console.Write("Ingrese el número de la tarea a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int indice) && indice >= 1 && indice <= tareas.Count)
            {
                tareas.RemoveAt(indice - 1);
                Console.WriteLine("Tarea eliminada.");
            }
            else
            {
                Console.WriteLine("Número de tarea inválido.");
            }
        }
    }
}

