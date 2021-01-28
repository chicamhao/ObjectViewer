using SharpGL;
using System.Drawing;

namespace ObjectBuilder
{
    class Cube : Object
    {
        public Cube() : base()
        {
            //vertices's coordinates x, y, z
            mVertices = new double[8, 3] {
            // Bottom vertices of a cube
            { -0.5f* Constants.WorldUnit, -0.5f* Constants.WorldUnit, -0.5f* Constants.WorldUnit },
            { -0.5f* Constants.WorldUnit, -0.5f* Constants.WorldUnit, 0.5f* Constants.WorldUnit },
            { 0.5f* Constants.WorldUnit, -0.5f* Constants.WorldUnit, 0.5f* Constants.WorldUnit },
            { 0.5f* Constants.WorldUnit, -0.5f* Constants.WorldUnit, -0.5f* Constants.WorldUnit },

            // Above vertices of a cube
            { -0.5f* Constants.WorldUnit, 0.5f* Constants.WorldUnit, -0.5f* Constants.WorldUnit },
            { -0.5f* Constants.WorldUnit, 0.5f* Constants.WorldUnit, 0.5f * Constants.WorldUnit},
            { 0.5f* Constants.WorldUnit, 0.5f* Constants.WorldUnit, 0.5f* Constants.WorldUnit },
            { 0.5f* Constants.WorldUnit, 0.5f* Constants.WorldUnit, -0.5f* Constants.WorldUnit },
            };

            mTextures = new double[4, 2] {
                {0f, 0f},    
                {0f, 1f* Constants.WorldUnit},    
                {1f* Constants.WorldUnit, 1f* Constants.WorldUnit},    
                {1f* Constants.WorldUnit, 0f}     
            };
            indicesObject = new int[6, 4]
            {
                {0, 1, 2, 3}, //bottom
                {4, 5, 6, 7}, //top
                {4, 0, 1, 5}, //left
                {5, 1, 2, 6}, //front
                {6, 2, 3, 7}, //right
                {7, 3, 0, 4}, //back
            };

            indicesOutLine = new int[12, 2]
            {
                {0,1},
                {1,2},

                {2,3},
                {3,0},

                {0,4},
                {4,5},

                {5,1},
                {5,6},

                {6,2},
                {6,7},

                {7,3},
                {7,4},
            };
        }

        //ref: https://stackoverflow.com/questions/33606951/opengl-cube-using-a-for-loop
        public override void DrawObject(OpenGL gl)
        {
            //setup color.
            gl.Color(color.R, color.G, color.B);

            //enable texture state and bind texture object to the path.
            if (texturePath != null)
            {
                gl.Enable(OpenGL.GL_TEXTURE_2D);
                texture.Create(gl, texturePath);
                texture.Bind(gl);
            }

            //draw each faces of the cube.
            gl.Begin(OpenGL.GL_QUADS);
            for (int i = 0; i < 6; i ++)
            {
                gl.TexCoord(mTextures[0, 0], mTextures[0, 1]);  gl.Vertex(mVertices[indicesObject[i, 0], 0], mVertices[indicesObject[i, 0], 1], mVertices[indicesObject[i, 0], 2]);
                gl.TexCoord(mTextures[1, 0], mTextures[1, 1]);  gl.Vertex(mVertices[indicesObject[i, 1], 0], mVertices[indicesObject[i, 1], 1], mVertices[indicesObject[i, 1], 2]);
                gl.TexCoord(mTextures[2, 0], mTextures[2, 1]);  gl.Vertex(mVertices[indicesObject[i, 2], 0], mVertices[indicesObject[i, 2], 1], mVertices[indicesObject[i, 2], 2]);
                gl.TexCoord(mTextures[3, 0], mTextures[3, 1]);  gl.Vertex(mVertices[indicesObject[i, 3], 0], mVertices[indicesObject[i, 3], 1], mVertices[indicesObject[i, 3], 2]); 
            }
            gl.End();

            //disable texture state 
            if (texturePath != null)
            {
                texture.Destroy(gl);
                gl.Disable(OpenGL.GL_TEXTURE_2D);
            }
        }

        public override void DrawOutlineObject(OpenGL gl)
        {
            //draw line
            gl.Begin(OpenGL.GL_LINE_LOOP);
            for (int i = 0; i < 12; i++)
            {
                gl.Vertex(mVertices[indicesOutLine[i, 0], 0], mVertices[indicesOutLine[i, 0], 1], mVertices[indicesOutLine[i, 0], 2]);
                gl.Vertex(mVertices[indicesOutLine[i, 1], 0], mVertices[indicesOutLine[i, 1], 1], mVertices[indicesOutLine[i, 1], 2]);
            }
            gl.End();
        }
    }
}
