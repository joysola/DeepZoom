using DeepZoom;
using System;
using System.Collections.Generic;
using System.Text;

namespace Joysola.DeepZoom
{
    public class TestTileSource : MultiScaleTileSource
    {
        public TestTileSource() : base(22202, 18545, 256, 0) { }/*base(0x8000000, 0x8000000, 256, 0) { }*/

        protected override object GetTileLayers(int tileLevel, int tilePositionX, int tilePositionY)
        {
            var path = @"D:\WorkSpace\DeepZoomFiles\654321\deepzoom_files";
            var zoom = tileLevel /*- 8*/;
            if (zoom >= 0)
            {
                //if (zoom>16)
                //{
                //    tileLevel = 16;
                //}
                return new Uri($"{path}\\{tileLevel}\\{tilePositionX}_{tilePositionY}.jpeg");
            }
            //return new Uri(string.Format("http://tah.openstreetmap.org/Tiles/tile/{0}/{1}/{2}.png", zoom, tilePositionX, tilePositionY));
            else
                return null;
        }
    }
}
