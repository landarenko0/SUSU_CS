using System;

namespace lr1
{
    internal class paral
    {
        // _x0, _y0, _z0 - координаты вершины параллелепипеда
        private double _x0, _y0, _z0, _length, _width, _height;

        public paral(double x0, double y0, double z0, double length, double width, double height)
        {
            if (length <= 0 || width <= 0 || height <= 0)
            {
                throw new Exception("Некорректные данные");
            }

            _x0 = x0;
            _y0 = y0;
            _z0 = z0;
            _length = length;
            _width = width;
            _height = height;
        }

        private paral(double length, double width, double height)
        {
            _length = length;
            _width = width;
            _height = height;
        }

        public void Move(double x, double y, double z)
        {
            _x0 = x;
            _y0 = y;
            _z0 = z;
        }

        public void Resize(double length, double width, double height)
        {
            _length = length;
            _width = width;
            _height = height;
        }

        // Построение наименьшего параллелепипеда, содержащего два заданных параллелепипеда
        public paral Union(paral paral)
        {
            // Первый параллелепипед
            // Начальная координата
            double x1 = _x0;
            double y1 = _y0;
            double z1 = _z0;

            // Вершина, находящаяся по диагонали от начальной координаты
            double x2 = _x0 + _width;
            double y2 = _y0 + _length;
            double z2 = _z0 + _height;

            // Второй паралллелепипед.
            // Начальная координата
            double x3 = paral._x0;
            double y3 = paral._y0;
            double z3 = paral._z0;

            // Вершина, находящаяся по диагонали от начальной координаты
            double x4 = paral._x0 + paral._width;
            double y4 = paral._y0 + paral._length;
            double z4 = paral._z0 + paral._height;

            // Проекциями поверхностей параллелепипедов на оси координат являются прямоугольники
            // Проекции первого параллелепипеда
            rectangle rect1XY = new rectangle(_x0, _y0, _width, _length);
            rectangle rect1XZ = new rectangle(_x0, _z0, _width, _height);
            rectangle rect1YZ = new rectangle(_y0, _z0, _length, _height);

            // Проекции второго параллелепипеда
            rectangle rect2XY = new rectangle(paral._x0, paral._y0, paral._width, paral._length);
            rectangle rect2XZ = new rectangle(paral._x0, paral._z0, paral._width, paral._height);
            rectangle rect2YZ = new rectangle(paral._y0, paral._z0, paral._length, paral._height);

            bool isInside = rect1XY.isInside(rect2XY) && rect1XZ.isInside(rect2XZ) && rect1YZ.isInside(rect2YZ);
            bool isAround = rect1XY.isAround(rect2XY) && rect1XZ.isAround(rect2XZ) && rect1YZ.isAround(rect2YZ);

            bool isIntersect = rect1XY.isIntersect(rect2XY) || rect1XZ.isIntersect(rect2XZ) || rect1YZ.isIntersect(rect2YZ);

            if (isInside || isAround)
            {
                // Случай, когда один параллелепипед находится внутри другого
                return new paral(Math.Max(_length, paral._length), Math.Max(_width, paral._width), Math.Max(_height, paral._height));
            }
            else if (isIntersect)
            {
                // Случай, когда параллелепипеды пересекаются
                double newLength, newWidth, newHeight;

                if (y1 <= y3 && y2 <= y4)
                {
                    newLength = Math.Abs(y4 - y1);

                    newWidth = Width(x1, x2, x3, x4);

                    newHeight = unionHeight(z1, z2, z3, z4, paral._height);
                }
                else if (y1 >= y3 && y2 >= y4)
                {
                    newLength = Math.Abs(y2 - y3);

                    newWidth = Width(x1, x2, x3, x4);

                    newHeight = unionHeight(z1, z2, z3, z4, paral._height);
                }
                else if (y1 >= y3 && y2 <= y4)
                {
                    newLength = paral._length;

                    newWidth = Width(x1, x2, x3, x4);

                    newHeight = unionHeight(z1, z2, z3, z4, paral._height);
                }
                else if (y1 <= y3 && y2 >= y4)
                {
                    newLength = _length;

                    newWidth = Width(x1, x2, x3, x4);

                    newHeight = unionHeight(z1, z2, z3, z4, paral._height);
                }
                else
                {
                    throw new Exception("Что-то не так");
                }

                return new paral(newLength, newWidth, newHeight);
            }
            else
            {
                // Случай, когда параллелепипеды не пересекаются
                double newLength, newWidth, newHeight;

                if (x2 > x4)
                {
                    newWidth = Math.Abs(x2 - x3);
                }
                else
                {
                    newWidth = Math.Abs(x4 - x1);
                }

                if (y2 > y4)
                {
                    newLength = Math.Abs(y2 - y3);
                }
                else
                {
                    newLength = Math.Abs(y4 - y1);
                }

                if (z2 > z4)
                {
                    newHeight = Math.Abs(z2 - z3);
                }
                else
                {
                    newHeight = Math.Abs(z4 - z1);
                }

                return new paral(newLength, newWidth, newHeight);
            }
        }

        // Построение параллелепипеда, являющегося пересечением двух заданных параллелепипедов
        public paral Intersection(paral paral)
        {
            // Проекциями поверхностей параллелепипедов на оси координат являются прямоугольники
            // Проекции первого параллелепипеда
            rectangle rect1XY = new rectangle(_x0, _y0, _width, _length);
            rectangle rect1XZ = new rectangle(_x0, _z0, _width, _height);
            rectangle rect1YZ = new rectangle(_y0, _z0, _length, _height);

            // Проекции второго параллелепипеда
            rectangle rect2XY = new rectangle(paral._x0, paral._y0, paral._width, paral._length);
            rectangle rect2XZ = new rectangle(paral._x0, paral._z0, paral._width, paral._height);
            rectangle rect2YZ = new rectangle(paral._y0, paral._z0, paral._length, paral._height);

            bool isIntersect = rect1XY.isIntersect(rect2XY) || rect1XZ.isIntersect(rect2XZ) || rect1YZ.isIntersect(rect2YZ);
            bool isInside = rect1XY.isInside(rect2XY) && rect1XZ.isInside(rect2XZ) && rect1YZ.isInside(rect2YZ);
            bool isAround = rect1XY.isAround(rect2XY) && rect1XZ.isAround(rect2XZ) && rect1YZ.isAround(rect2YZ);

            if (isIntersect)
            {
                double x1 = _x0;
                double y1 = _y0;
                double z1 = _z0;

                double x2 = _x0 + _width;
                double y2 = _y0 + _length;
                double z2 = _z0 + _height;

                double x3 = paral._x0;
                double y3 = paral._y0;
                double z3 = paral._z0;

                double x4 = paral._x0 + paral._width;
                double y4 = paral._y0 + paral._length;
                double z4 = paral._z0 + paral._height;

                double newLength, newWidth, newHeight;

                if (isInside || isAround)
                {
                    return new paral(Math.Min(_length, paral._length), Math.Min(_width, paral._width), Math.Min(_height, paral._height));
                }

                if (y1 <= y3 && y2 <= y4)
                {
                    newLength = Math.Abs(y2 - y3);

                    //newWidth = Math.Abs(x2 - x3);
                    newWidth = intersectionWidth(x1, x2, x3, x4, paral._width);

                    if (newWidth > _width)
                    {
                        newWidth = _width;
                    }

                    newHeight = intersectionHeight(z1, z2, z3, z4, paral._height);
                }
                else if (y1 >= y3 && y2 >= y4)
                {
                    newLength = Math.Abs(y4 - y1);

                    //newWidth = Math.Abs(x4 - x1);
                    newWidth = intersectionWidth(x1, x2, x3, x4, paral._width);

                    if (newWidth > _width)
                    {
                        newWidth = paral._width;
                    }

                    newHeight = intersectionHeight(z1, z2, z3, z4, paral._height);
                }
                else if (y3 >= y1 && y4 <= y2)
                {
                    newLength = paral._length;

                    //newWidth = paral._width;
                    newWidth = intersectionWidth(x1, x2, x3, x4, paral._width);

                    newHeight = intersectionHeight(z1, z2, z3, z4, paral._height);
                }
                else if (y3 <= y1 && y4 >= y2)
                {
                    newLength = _length;

                    //newWidth = paral._width;
                    newWidth = intersectionWidth(x1, x2, x3, x4, paral._width);

                    newHeight = intersectionHeight(z1, z2, z3, z4, paral._height);
                }
                else
                {
                    throw new Exception("Что-то не так");
                }

                // Соприкосновение поверхностей. Параллелепипед не существует
                if (newLength == 0 || newWidth == 0 || newHeight == 0)
                {
                    Console.WriteLine("Соприкосновение поверхностей. Параллелепипед не существует");
                    return new paral(0, 0, 0);
                }
                
                return new paral(newLength, newWidth, newHeight);
            }
            else
            {
                Console.WriteLine("Нет пересечения параллелепипедов.");
                return new paral(0, 0, 0);
            }
        }

        public override string ToString()
        {
            return $"Длина = {_length}, ширина = {_width}, высота = {_height}";
        }

        public string printCoordinates()
        {
            return $"x = {_x0}, y = {_y0}, z = {_z0}";
        }

        private double Width(double x1, double x2, double x3, double x4)
        {
            double newWidth;

            if (x1 <= x3 && x2 <= x4)
            {
                newWidth = Math.Abs(x4 - x1);
            }
            else if (x1 >= x3 && x2 <= x4)
            {
                newWidth = Math.Abs(x4 - x3);
            }
            else if (x1 >= x3 && x2 >= x4)
            {
                newWidth = Math.Abs(x2 - x3);
            }
            else
            {
                newWidth = Math.Abs(x2 - x1);
            }

            return newWidth;
        }

        private double unionHeight(double z1, double z2, double z3, double z4, double paral_height)
        {
            double newHeight;

            if (z1 <= z3 && z2 <= z4)
            {
                newHeight = Math.Abs(z4 - z1);
            }
            else if (z1 >= z3 && z2 >= z4)
            {
                newHeight = Math.Abs(z2 - z3);
            }
            else if (z1 >= z3 && z2 <= z4)
            {
                newHeight = paral_height;
            }
            else if (z1 <= z3 && z2 >= z4)
            {
                newHeight = _length;
            }
            else
            {
                throw new Exception("Что-то не так");
            }

            return newHeight;
        }

        private double intersectionHeight(double z1, double z2, double z3, double z4, double paral_height)
        {
            double newHeight;

            if (z1 <= z3 && z2 <= z4)
            {
                newHeight = Math.Abs(z2 - z3);
            }
            else if (z1 >= z3 && z2 >= z4)
            {
                newHeight = Math.Abs(z4 - z1);
            }
            else if (z1 >= z3 && z2 <= z4)
            {
                newHeight = _height;
            }
            else if (z1 <= z3 && z2 >= z4)
            {
                newHeight = paral_height;
            }
            else
            {
                throw new Exception("Что-то не так");
            }

            return newHeight;
        }

        private double intersectionWidth(double x1, double x2, double x3, double x4, double paral_width)
        {
            double newWidth;

            if (x1 <= x3 && x2 <= x4)
            {
                newWidth = Math.Abs(x2 - x3);
            }
            else if (x1 >= x3 && x2 >= x4)
            {
                newWidth = Math.Abs(x4 - x1);
            }
            else if (x1 >= x3 && x2 <= x4)
            {
                newWidth = _height;
            }
            else if (x1 <= x3 && x2 >= x4)
            {
                newWidth = paral_width;
            }
            else
            {
                throw new Exception("Что-то не так");
            }

            return newWidth;
        }
    }
}