using System;

namespace lr1
{
    // Класс, который рассматривает проекции поверхностей параллелепипеда на оси координат как прямоугольники

    internal class rectangle
    {
        private double _x0, _y0, _length, _width;

        public rectangle(double x0, double y0, double width, double length)
        {
            if (width <= 0 || length <= 0)
            {
                throw new Exception("Некорректные данные");
            }

            _x0 = x0;
            _y0 = y0;
            _length = length;
            _width = width;
        }

        public bool isIntersect(rectangle rect)
        {
            double x1 = _x0;
            double y1 = _y0;

            double x2 = _x0 + _width;
            double y2 = _y0 + _length;

            double x3 = rect._x0;
            double y3 = rect._y0;

            double x4 = rect._x0 + rect._width;
            double y4 = rect._y0 + rect._length;

            bool hasIntersection = x1 <= x4 && x2 >= x3 && y1 <= y4 && y2 >= y3;
            return hasIntersection;
        }

        public bool isInside(rectangle rect)
        {
            double x1 = _x0;
            double y1 = _y0;

            double x2 = _x0 + _width;
            double y2 = _y0 + _length;

            double x3 = rect._x0;
            double y3 = rect._y0;

            double x4 = rect._x0 + rect._width;
            double y4 = rect._y0 + rect._length;

            bool isInside = x1 <= x3 && x2 >= x4 && y1 <= y3 && y2 >= y4;
            return isInside;
        }

        public bool isAround(rectangle rect)
        {
            double x1 = _x0;
            double y1 = _y0;

            double x2 = _x0 + _width;
            double y2 = _y0 + _length;

            double x3 = rect._x0;
            double y3 = rect._y0;

            double x4 = rect._x0 + rect._width;
            double y4 = rect._y0 + rect._length;

            bool isAround = x1 >= x3 && x2 <= x4 && y1 >= y3 && y2 <= y4;
            return isAround;
        }
    }
}