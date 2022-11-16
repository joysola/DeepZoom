using DeepZoom.Marks.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace DeepZoom.Marks.Tools
{
    public static class CanvasCoordinationExtension
    {
        #region ShapeMark坐标转换扩展方法
        /// <summary>
        /// Canvas坐标转Msi图像坐标
        /// </summary>
        /// <param name="shapeMark"></param>
        /// <param name="canPiont"></param>
        /// <returns></returns>
        public static Point CanvasToMsi(this DeepZoomMark shapeMark, Point canPiont, int slideZoom = 1)
        {
            Point offset = shapeMark.Offset;
            Point result = default(Point);
            result.X = (canPiont.X + offset.X) / (shapeMark.Scale * slideZoom);
            result.Y = (canPiont.Y + offset.Y) / (shapeMark.Scale * slideZoom);
            return result;
        }
        /// <summary>
        /// Msi图像坐标转Canvas坐标
        /// </summary>
        /// <param name="annoBase"></param>
        /// <param name="msiPiont"></param>
        /// <returns></returns>
        public static Point MsiToCanvas(this DeepZoomMark shapeMark, Point msiPiont, int slideZoom = 1)
        {
            Point offset = shapeMark.Offset;
            Point result = default(Point);
            result.X = msiPiont.X * (shapeMark.Scale * slideZoom) - offset.X;
            result.Y = msiPiont.Y * (shapeMark.Scale * slideZoom) - offset.Y;
            return result;
        }

        public static Rect MsiToCanvas(this DeepZoomMark shapeMark, Rect msiRect, int slideZoom = 1)
        {
            Point offset = shapeMark.Offset;
            Rect result = default;

            result.X = msiRect.X * (shapeMark.Scale * slideZoom) - offset.X;
            result.Y = msiRect.Y * (shapeMark.Scale * slideZoom) - offset.Y;
            result.Width = msiRect.Width * (shapeMark.Scale * slideZoom);
            result.Height = msiRect.Height * (shapeMark.Scale * slideZoom);
            return result;
        }
        #endregion ShapeMark坐标转换扩展方法

        #region Point坐标转换扩展方法
        /// <summary>
        /// Canvas坐标转Msi图像坐标
        /// </summary>
        /// <param name="canPiont"></param>
        /// <param name="msi"></param>
        /// <param name="slideZoom"></param>
        /// <returns></returns>
        public static Point CanvasToMsi(this Point canPiont, Point offset, double scale, int slideZoom = 1)
        {

            Point result = default;
            result.X = (canPiont.X + offset.X) / (scale * slideZoom);
            result.Y = (canPiont.Y + offset.Y) / (scale * slideZoom);
            return result;
        }
        /// <summary>
        /// Canvas坐标转Msi图像坐标
        /// </summary>
        /// <param name="canRect"></param>
        /// <param name="offset"></param>
        /// <param name="scale"></param>
        /// <param name="slideZoom"></param>
        /// <returns></returns>
        public static Rect CanvasToMsi(this Rect canRect, Point offset, double scale, int slideZoom = 1)
        {
            Rect result = default;
            result.X = (canRect.X + offset.X) / (scale * slideZoom);
            result.Y = (canRect.Y + offset.Y) / (scale * slideZoom);
            result.Width = canRect.Width / (scale * slideZoom);
            result.Height = canRect.Height / (scale * slideZoom);
            return result;
        }
        /// <summary>
        /// Msi图像坐标转Canvas坐标
        /// </summary>
        /// <param name="msiPiont"></param>
        /// <param name="msi"></param>
        /// <param name="slideZoom"></param>
        /// <returns></returns>
        public static Point MsiToCanvas(this Point msiPiont, Point offset, double scale, int slideZoom = 1)
        {

            Point result = default;
            result.X = msiPiont.X * (scale * slideZoom) - offset.X;
            result.Y = msiPiont.Y * (scale * slideZoom) - offset.Y;
            return result;
        }
        // 旋转中心是(0,0)时的坐标旋转公式
        // x1 = cos(angle) * x - sin(angle) * y;
        // y1 = cos(angle) * y + sin(angle) * x;
        /// <summary>
        /// 坐标旋转公式
        /// </summary>
        /// <param name="strat">旋转起点坐标</param>
        /// <param name="center">旋转中心坐标</param>
        /// <param name="angle">旋转角度</param>
        /// <returns></returns>
        public static Point GetRotatePoint(this Point strat, Point center, double angle)
        {
            Point result = default;
            double radian = angle * 2 * Math.PI / 360.0; // 度数转弧度
            // strat.X - center.X 是 实际旋转的 投影x轴的距离
            result.X = (strat.X - center.X) * Math.Cos(radian) + (strat.Y - center.Y) * Math.Sin(radian) + center.X;
            result.Y = (strat.Y - center.Y) * Math.Cos(radian) - (strat.X - center.X) * Math.Sin(radian) + center.Y;
            return result;
        }
        #endregion Point坐标转换扩展方法
    }
}
