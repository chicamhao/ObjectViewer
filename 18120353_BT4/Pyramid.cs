using SharpGL;
using System.Drawing;

namespace ObjectBuilder
{
    class Pyramid : Object
    {
        public Pyramid() : base()
        {
            //vertices's coordinates x, y, z
            mVertices = new double[5, 3] {
            // Bottom vertices of pyramid
            { -0.5f, -0.5f, -0.5f },
            { -0.5f, -0.5f, 0.5f },
            { 0.5f, -0.5f, 0.5f },
            { 0.5f, -0.5f, -0.5f },

            // top vertex
            { 0f, 0.5f, 0f },
            };

            mTextures = new double[3, 2] {
                { 0.0f, 0.0f }, // Lower-left corner
                { 1.0f, 0.0f }, // Lower-right corner
                { 0.5f, 1.0f } // Top-center corner
            };

            indicesObject = new int[4, 3]
            {
                {0, 1, 4}, //right triangle
                {3, 0, 4}, //back triangle
                {2, 3, 4}, //left triangle
                {1, 2, 4}, //front triangle
            };

            indicesOutLine = new int[8, 2]
            {
                //bottom edges
                {0,1},
                {1,2},

                {2,3},
                {3,0},

                //side edges
                {0,4},
                {1,4},

                {2,4},
                {3,4},
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

            //draw each triangle faces of the pyramid.
            gl.Begin(OpenGL.GL_TRIANGLES);
            for (int i = 0; i < 4; i++)
            {
                gl.TexCoord(mTextures[0, 0], mTextures[0, 1]); gl.Vertex(mVertices[indicesObject[i, 0], 0], mVertices[indicesObject[i, 0], 1], mVertices[indicesObject[i, 0], 2]);
                gl.TexCoord(mTextures[1, 0], mTextures[1, 1]); gl.Vertex(mVertices[indicesObject[i, 1], 0], mVertices[indicesObject[i, 1], 1], mVertices[indicesObject[i, 1], 2]);
                gl.TexCoord(mTextures[2, 0], mTextures[2, 1]); gl.Vertex(mVertices[indicesObject[i, 2], 0], mVertices[indicesObject[i, 2], 1], mVertices[indicesObject[i, 2], 2]);
            }
            gl.End();

            //draw bottom face
            gl.Begin(OpenGL.GL_QUADS);
            gl.TexCoord(0, 0f);     gl.Vertex(mVertices[0, 0], mVertices[0, 1], mVertices[0, 2]);
            gl.TexCoord(1f ,0f);    gl.Vertex(mVertices[1, 0], mVertices[1, 1], mVertices[1, 2]);
            gl.TexCoord(1f, 1f);    gl.Vertex(mVertices[2, 0], mVertices[2, 1], mVertices[2, 2]);
            gl.TexCoord(0f, 1f);    gl.Vertex(mVertices[3, 0], mVertices[3, 1], mVertices[3, 2]);
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
            for (int i = 0; i < 8; i++)
            {
                gl.Vertex(mVertices[indicesOutLine[i, 0], 0], mVertices[indicesOutLine[i, 0], 1], mVertices[indicesOutLine[i, 0], 2]);
                gl.Vertex(mVertices[indicesOutLine[i, 1], 0], mVertices[indicesOutLine[i, 1], 1], mVertices[indicesOutLine[i, 1], 2]);
            }
            gl.End();
        }
    }
}
