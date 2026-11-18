using System;

namespace InterfacesPractice
{
    // =========================================================================
    // ІНТЕРФЕЙСИ
    // =========================================================================

    // Загальне завдання: інтерфейс малювання об'єктів
    interface IDrawable
    {
        void Draw();
    }

    // Домашнє завдання: інтерфейс масштабування фігур
    interface IScalable
    {
        void Scale(double factor);
    }

    // =========================================================================
    // КЛАСИ, ЯКІ РЕАЛІЗУЮТЬ ІНТЕРФЕЙСИ
    // =========================================================================

    // Клас Точка реалізує інтерфейс IDrawable
    class Point : IDrawable
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public void Draw()
        {
            Console.WriteLine("Малюємо точку (Point) у координатах (" + X + "; " + Y + ").");
        }
    }

    // Клас Коло реалізує одночасно два інтерфейси: IDrawable та IScalable
    class Circle : IDrawable, IScalable
    {
        public double CenterX { get; set; }
        public double CenterY { get; set; }
        public double Radius { get; private set; }

        public Circle(double x, double y, double radius)
        {
            CenterX = x;
            CenterY = y;
            Radius = radius;
        }

        // Реалізація методу з інтерфейсу IDrawable
        public void Draw()
        {
            Console.WriteLine("Малюємо коло (Circle) з центром у (" + CenterX + "; " + CenterY + ") та радіусом R = " + Radius + ".");
        }

        // Реалізація методу з інтерфейсу IScalable (Домашнє завдання)
        public void Scale(double factor)
        {
            if (factor > 0)
            {
                Radius = Radius * factor;
                Console.WriteLine("   -> Коло масштабовано у " + factor + " раз(и). Новий радіус R = " + Radius + ".");
            }
            else
            {
                Console.WriteLine("   -> Помилка: коефіцієнт масштабування має бути більшим за 0.");
            }
        }
    }

    // =========================================================================
    // ГОЛОВНИЙ КЛАС ПРОГРАМИ
    // =========================================================================

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Створюємо об'єкти класів Point та Circle
            Point point = new Point(3, 7);
            Circle circle = new Circle(0, 0, 5);

            Console.WriteLine("=== ЗАГАЛЬНЕ ЗАВДАННЯ: Робота через інтерфейс IDrawable ===");
            // Зберігаємо різні об'єкти в єдиному масиві інтерфейсного типу IDrawable[]
            IDrawable[] drawableObjects = new IDrawable[] { point, circle };

            foreach (IDrawable item in drawableObjects)
            {
                item.Draw();
            }

            Console.WriteLine("\n=== ДОМАШНЄ ЗАВДАННЯ: Масштабування через інтерфейс IScalable ===");
            // Працюємо з колом через посилання типу IScalable
            IScalable scalableShape = circle;
            scalableShape.Scale(2.5);

            // Перевіряємо результат після зміни масштабу
            circle.Draw();
        }
    }
}
