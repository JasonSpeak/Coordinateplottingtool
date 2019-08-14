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
        private int _lineX1;

        public int LineX1
        {
            get { return _lineX1; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _lineX1 = value;
                RaisePropertyChanged(() => LineX1);
            }
        }
        /// <summary>
        /// 直线点P1的y坐标
        /// </summary>
        private int _lineY1;

        public int LineY1
        {
            get { return _lineY1; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _lineY1 = value;
                RaisePropertyChanged(() => LineY1);
            }
        }
        /// <summary>
        /// 直线点P2的x坐标
        /// </summary>
        private int _lineX2;

        public int LineX2
        {
            get { return _lineX2; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _lineX2 = value;
                RaisePropertyChanged(() => LineX2);
            }
        }
        /// <summary>
        /// 直线点P1的y坐标
        /// </summary>
        private int _lineY2;

        public int LineY2
        {
            get { return _lineY2; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _lineY2 = value;
                RaisePropertyChanged(() => LineY2);
            }
        }
        #endregion

        #region 三角形的坐标值
        /// <summary>
        /// 三角形点p1的x坐标
        /// </summary>
        private int _triangleX1;
        public int TriangleX1
        {
            get { return _triangleX1; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _triangleX1 = value;
                RaisePropertyChanged(() => TriangleX1);
            }
        }
        /// <summary>
        /// 三角形点p1的y坐标
        /// </summary>
        private int _triangleY1;
        public int TriangleY1
        {
            get { return _triangleY1; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _triangleY1 = value;
                RaisePropertyChanged(() => TriangleY1);
            }
        }
        /// <summary>
        /// 三角形点p2的x坐标
        /// </summary>
        private int _triangleX2;
        public int TriangleX2
        {
            get { return _triangleX2; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _triangleX2 = value;
                RaisePropertyChanged(() => TriangleX2);
            }
        }
        /// <summary>
        /// 三角形点p2的y坐标
        /// </summary>
        private int _triangleY2;
        public int TriangleY2
        {
            get { return _triangleY2; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _triangleY2 = value;
                RaisePropertyChanged(() => TriangleY2);
            }
        }
        /// <summary>
        /// 三角形点p3的x坐标
        /// </summary>
        private int _triangleX3;
        public int TriangleX3
        {
            get { return _triangleX3; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _triangleX3 = value;
                RaisePropertyChanged(() => TriangleX3);
            }
        }
        /// <summary>
        /// 三角形点p3的y坐标
        /// </summary>
        private int _triangleY3;
        public int TriangleY3
        {
            get { return _triangleY3; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _triangleY3 = value;
                RaisePropertyChanged(() => TriangleY3);
            }
        }



        private string _triangleP1;

        public string TriangleP1
        {
            get { return _triangleP1; }
            set
            {
                if (TriangleX1 == 0 && TriangleY1 == 0)
                {
                    value = "100,100";
                }
                _triangleP1 = value;
                RaisePropertyChanged(() => TriangleP1);
            }
        }

        private string _triangleP2;

        public string TriangleP2
        {
            get { return _triangleP2; }
            set
            {
                if (TriangleX2 == 0 && TriangleY2 == 0)
                {
                    value = "400,400";
                }
                _triangleP2 = value; RaisePropertyChanged(() => TriangleP2);
            }
        }

        private string _triangleP3;

        public string TriangleP3
        {
            get { return _triangleP3; }
            set
            {
                if (TriangleX3 == 0 && TriangleY3 == 0)
                {
                    value = "400,450";
                }
                _triangleP3 = value; RaisePropertyChanged(() => TriangleP3);
            }
        }
        #endregion
    }
}
