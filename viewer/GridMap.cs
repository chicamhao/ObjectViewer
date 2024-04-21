using SharpGL;

namespace ObjectBuilder
{
    public sealed class GridMap
    {
        private readonly uint _unitMap;

        public GridMap(uint worldUnit)
        {
            _unitMap = worldUnit;
        }

        public void DrawGridMap(OpenGL gl, uint sizeOfMap)
        {
            float halfOfMap = sizeOfMap / 2 * _unitMap;
            float quarterOfMapq = sizeOfMap / 4 * _unitMap;
            float sizeOfGid = (float)sizeOfMap / 20 * _unitMap;

            //1. draw grid map coordinates x, y, z
            gl.LineWidth(3.0f * _unitMap);
            gl.Begin(OpenGL.GL_LINES);

            //x with red
            gl.Color(1f, 0, 0, 0);
            gl.Vertex(-quarterOfMapq, 0.0f, 0.0f); gl.Vertex(quarterOfMapq, 0.0f, 0.0f);

            //y with green
            gl.Color(0f, 1f, 0.0f, 0.0f);
            gl.Vertex(0.0f, -quarterOfMapq, 0.0f); gl.Vertex(0, quarterOfMapq, 0.0f);

            //z with blue
            gl.Color(0.0f, 0.0f, 1f, 0.0f);
            gl.Vertex(0.0f, 0.0f, -quarterOfMapq); gl.Vertex(0.0f, 0.0f, quarterOfMapq);
            gl.End();


            //2. draw grid map
            gl.LineWidth(2.0f);
            gl.Color(0.5f, 0.5f, 0.5f, 0.0f);
            gl.Begin(OpenGL.GL_LINES);

            //highlight which lines located on the coordinates
            gl.Vertex(quarterOfMapq, 0.0f, 0.0f); gl.Vertex(halfOfMap, 0.0f, 0.0f);
            gl.Vertex(-quarterOfMapq, 0.0f, 0.0f); gl.Vertex(-halfOfMap, 0.0f, 0.0f);
            gl.Vertex(0.0f, 0.0f, quarterOfMapq); gl.Vertex(0.0f, 0.0f, halfOfMap);
            gl.Vertex(0.0f, 0.0f, -quarterOfMapq); gl.Vertex(0.0f, 0.0f, -halfOfMap);

            //highlight which lines located on the borders.
            gl.Vertex(-halfOfMap, 0.0f, -halfOfMap); gl.Vertex(halfOfMap, 0.0f, -halfOfMap);
            gl.Vertex(-halfOfMap, 0.0f, halfOfMap); gl.Vertex(halfOfMap, 0.0f, halfOfMap);
            gl.Vertex(-halfOfMap, 0.0f, -halfOfMap); gl.Vertex(-halfOfMap, 0.0f, halfOfMap);
            gl.Vertex(halfOfMap, 0.0f, -halfOfMap); gl.Vertex(halfOfMap, 0.0f, halfOfMap);

            gl.End();


            //other line of grid map.
            gl.LineWidth(1f);
            gl.Color(0.3f, 0.3f, 0.3f, 0.0f);
            for (float idx = -halfOfMap; idx <= halfOfMap; idx += sizeOfGid)
            {
                if (idx != 0)
                {
                    gl.Begin(OpenGL.GL_LINES);
                    gl.Vertex(-halfOfMap, 0.0f, idx); gl.Vertex(halfOfMap, 0.0f, idx);
                    gl.Vertex(idx, 0.0f, -halfOfMap); gl.Vertex(idx, 0, halfOfMap);
                    gl.End();
                }
            }
        }
    }
}
