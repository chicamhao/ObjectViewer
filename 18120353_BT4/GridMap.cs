using SharpGL;

namespace ObjectBuilder
{
    class GridMap
    {
        private uint UnitMap;

        public GridMap(){
            this.UnitMap = 1;
        }

        public GridMap(uint worldUnit)
        {
            this.UnitMap = worldUnit;
        }

        public void DrawGridMap(OpenGL gl, uint SizeOfMap)
        {
            float HalfOfMap = SizeOfMap / 2* UnitMap;
            float QuarterOfMap = SizeOfMap / 4* UnitMap;
            float SizeOfGid = (float)SizeOfMap / 20* UnitMap;

            //1. draw grid map coordinates x, y, z
            gl.LineWidth(3.0f* UnitMap);
            gl.Begin(OpenGL.GL_LINES);

            //x with red
            gl.Color(1f, 0, 0, 0);
            gl.Vertex(-QuarterOfMap, 0.0f, 0.0f); gl.Vertex(QuarterOfMap, 0.0f, 0.0f);

            //y with green
            gl.Color(0f, 1f, 0.0f, 0.0f);
            gl.Vertex(0.0f, -QuarterOfMap, 0.0f); gl.Vertex(0, QuarterOfMap, 0.0f);

            //z with blue
            gl.Color(0.0f, 0.0f, 1f, 0.0f);
            gl.Vertex(0.0f, 0.0f, -QuarterOfMap); gl.Vertex(0.0f, 0.0f, QuarterOfMap);
            gl.End();


            //2. draw grid map
            gl.LineWidth(2.0f);
            gl.Color(0.5f, 0.5f, 0.5f, 0.0f);
            gl.Begin(OpenGL.GL_LINES);

            //highlight which lines located on the coordinates
            gl.Vertex(QuarterOfMap, 0.0f, 0.0f); gl.Vertex(HalfOfMap, 0.0f, 0.0f);
            gl.Vertex(-QuarterOfMap, 0.0f, 0.0f); gl.Vertex(-HalfOfMap, 0.0f, 0.0f);
            gl.Vertex(0.0f, 0.0f, QuarterOfMap); gl.Vertex(0.0f, 0.0f, HalfOfMap);
            gl.Vertex(0.0f, 0.0f, -QuarterOfMap); gl.Vertex(0.0f, 0.0f, -HalfOfMap);

            //highlight which lines located on the borders.
            gl.Vertex(-HalfOfMap, 0.0f, -HalfOfMap); gl.Vertex(HalfOfMap, 0.0f, -HalfOfMap);
            gl.Vertex(-HalfOfMap, 0.0f, HalfOfMap); gl.Vertex(HalfOfMap, 0.0f, HalfOfMap);
            gl.Vertex(-HalfOfMap, 0.0f, -HalfOfMap); gl.Vertex(-HalfOfMap, 0.0f, HalfOfMap);
            gl.Vertex(HalfOfMap, 0.0f, -HalfOfMap); gl.Vertex(HalfOfMap, 0.0f, HalfOfMap);

            gl.End();


            //other line of grid map.
            gl.LineWidth(1f);
            gl.Color(0.3f, 0.3f, 0.3f, 0.0f);
            for (float idx = -HalfOfMap; idx <= HalfOfMap; idx += SizeOfGid)
            {
                if (idx != 0)
                {
                    gl.Begin(OpenGL.GL_LINES);
                    gl.Vertex(-HalfOfMap, 0.0f, idx); gl.Vertex(HalfOfMap, 0.0f, idx);
                    gl.Vertex(idx, 0.0f, -HalfOfMap); gl.Vertex(idx, 0, HalfOfMap);
                    gl.End();
                }
            }
        }
    }
}
