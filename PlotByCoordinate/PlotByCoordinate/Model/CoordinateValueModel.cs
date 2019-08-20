using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotByCoordinate.Model
{
    public class CoordinateValueModel:ObservableObject
    {
        #region 直线的坐标值
        /// <summary>
        /// 直线点P1的x坐标
        /// </summary>
        private double _lineX1;

        public double LineX1
        {
            get { return _lineX1; }
            set
            {
                if (value>640)
                {
                    value = 0;
                }
                _lineX1 = (double)value;
                RaisePropertyChanged(() => LineX1);
            }
        }
        /// <summary>
        /// 直线点P1的y坐标
        /// </summary>
        private double _lineY1;

        public double LineY1
        {
            get { return _lineY1; }
            set
            {
                if (value>550)
                {
                    value = 0;
                }
                _lineY1 = (double)value;
                RaisePropertyChanged(() => LineY1);
            }
        }
        /// <summary>
        /// 直线点P2的x坐标
        /// </summary>
        private double _lineX2;

        public double LineX2
        {
            get { return _lineX2; }
            set
            {
                if (value>640)
                {
                    value = 0;
                }
                _lineX2 = (double)value;
                RaisePropertyChanged(() => LineX2);
            }
        }
        /// <summary>
        /// 直线点P1的y坐标
        /// </summary>
        private double _lineY2;

        public double LineY2
        {
            get { return _lineY2; }
            set
            {
                if (value>550)
                {
                    value = 0;
                }
                _lineY2 = (int)value;
                RaisePropertyChanged(() => LineY2);
            }
        }
        #endregion

        #region 三角形的坐标值
        /// <summary>
        /// 三角形点p1的x坐标
        /// </summary>
        private double _triangleX1;
        public double TriangleX1
        {
            get { return _triangleX1; }
            set
            {
                if (value > 640)
                {
                    value = 0;
                }
                _triangleX1 = (double)value;
                RaisePropertyChanged(() => TriangleX1);
            }
        }
        /// <summary>
        /// 三角形点p1的y坐标
        /// </summary>
        private double _triangleY1;
        public double TriangleY1
        {
            get { return _triangleY1; }
            set
            {
                if (value>550)
                {
                    value = 0;
                }
                _triangleY1 = (double)value;
                RaisePropertyChanged(() => TriangleY1);
            }
        }
        /// <summary>
        /// 三角形点p2的x坐标
        /// </summary>
        private double _triangleX2;
        public double TriangleX2
        {
            get { return _triangleX2; }
            set
            {
                if (value>640)
                {
                    value = 0;
                }
                _triangleX2 = (double)value;
                RaisePropertyChanged(() => TriangleX2);
            }
        }
        /// <summary>
        /// 三角形点p2的y坐标
        /// </summary>
        private double _triangleY2;
        public double TriangleY2
        {
            get { return _triangleY2; }
            set
            {
                if (value>550)
                {
                    value = 0;
                }
                _triangleY2 = (double)value;
                RaisePropertyChanged(() => TriangleY2);
            }
        }
        /// <summary>
        /// 三角形点p3的x坐标
        /// </summary>
        private double _triangleX3;
        public double TriangleX3
        {
            get { return _triangleX3; }
            set
            {
                if (value>640)
                {
                    value = 0;
                }
                _triangleX3 = (double)value;
                RaisePropertyChanged(() => TriangleX3);
            }
        }
        /// <summary>
        /// 三角形点p3的y坐标
        /// </summary>
        private double _triangleY3;
        public double TriangleY3
        {
            get { return _triangleY3; }
            set
            {
                if (value>550)
                {
                    value = 0;
                }
                _triangleY3 = (double)value;
                RaisePropertyChanged(() => TriangleY3);
            }
        }


        private double xPos;

        public double XPos
        {
            get { return xPos; }
            set
            {
                xPos = value;
                RaisePropertyChanged(() => XPos);
            }
        }


        private double yPos;

        public double YPos
        {
            get { return yPos; }
            set
            {
                yPos = value;
                RaisePropertyChanged(() => YPos);
            }
        }


        private double linexPos;

        public double LineXPos
        {
            get { return linexPos; }
            set
            {
                linexPos = value;
                RaisePropertyChanged(() => LineXPos);
            }
        }


        private double lineyPos;

        public double LineYPos
        {
            get { return lineyPos; }
            set
            {
                lineyPos = value;
                RaisePropertyChanged(() => LineYPos);
            }
        }

        private string canSee;

        public string CanSee
        {
            get { return canSee; }
            set {
                canSee = value;
                RaisePropertyChanged(() => CanSee);
            }
        }
        private string linecanSee;

        public string LineCanSee
        {
            get { return linecanSee; }
            set
            {
                linecanSee = value;
                RaisePropertyChanged(() => LineCanSee);
            }
        }


        #endregion
    }
}
