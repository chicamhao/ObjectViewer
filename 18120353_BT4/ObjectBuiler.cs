using SharpGL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;



namespace ObjectBuilder
{
    public partial class ObjectBuiler : Form
    {
        List<Object> listObjects = new List<Object>();
        Camera camera = new Camera(Constants.CameraUnit);
        Object currentObject = new Object();

        public ObjectBuiler()
        {
            InitializeComponent();

            //we don't wan't enabled feature buttons when non object selected.
            EnabledButtonsClick(false);
        }

        private void openGLControl1_OpenGLInitialized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl1.OpenGL;

            //clear begin scene.
            gl.ClearColor(0, 0, 0, 0);
            // Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            // Load the identity.
            gl.LoadIdentity();
        }

        private void openGLControl1_Resized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl1.OpenGL;

            //set current matrix mode to transform local space to world space.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);

            //set view matrix mode to transform world space to clip space (transform the projection matrix).
            camera.UpdateLookAt(gl);

            //set current matrix mode to transform view space to clip space, we use perspective mode
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.Perspective(70, openGLControl1.Width * 1f / openGLControl1.Height, 1, 50);

            //set viewport to stranform clip space to screen space.
            gl.Viewport(
                0, 0,
                openGLControl1.Width,
                openGLControl1.Height);

            camera.ZoomCamera("In");
        }

        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {
            OpenGL gl = openGLControl1.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            //set current matrix mode to transform local space to world space.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);

            //transform the projection matrix.
            camera.UpdateLookAt(gl);

            // Load the identity.
            gl.LoadIdentity();

            //transform the projection matrix
            camera.UpdateLookAt(gl);

            //create grid map
            GridMap gridMap = new GridMap(Constants.WorldUnit);

            // Draw a grid map with parameter 2 is the size.
            gridMap.DrawGridMap(gl, 10 * Constants.WorldUnit);

            //drawing all objects.
            foreach (Object obj in listObjects)
            {
                //update ischoose to select a fit outline
                if (obj == currentObject)
                    obj.IsChoose = true;
                else
                    obj.IsChoose = false;

                obj.DrawSoildObject(gl);
            }

            gl.Flush();

            //show eye coordinate of camera to the screen
            ShowEyeCoord();
        }


        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //input keycode to update camera position.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Z:
                    camera.ZoomCamera("In");
                    break;
                case Keys.X:
                    camera.ZoomCamera("Out");
                    break;
                case Keys.Left:
                    camera.RotateCamera("Left");
                    break;
                case Keys.Right:
                    camera.RotateCamera("Right");
                    break;
                case Keys.Up:
                    camera.RotateCamera("Up");
                    break;
                case Keys.Down:
                    camera.RotateCamera("Down");
                    break;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Create object method

        private void CreateCube_CLick(object sender, EventArgs e)
        {
            //create object
            Cube cube = new Cube();

            //add the new object to list and UI list
            listObjects.Add(cube);

            listBoxObjects.Items.Add(cube);
        }
        private void CreatePrism_CLick(object sender, EventArgs e)
        {
            //create object
            Prism prism = new Prism();

            //add the new object to list and UI list
            listObjects.Add(prism);

            listBoxObjects.Items.Add(prism);
        }
        private void CreatePyramid_Click(object sender, EventArgs e)
        {
            //create object
            Pyramid pyramid = new Pyramid();

            //add the new object to list and UI list
            listObjects.Add(pyramid);

            listBoxObjects.Items.Add(pyramid);
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Update transform method
        private void TranslateX_TextChanged(object sender, EventArgs e)
        {
            float value;
            if (float.TryParse(TranslateX.Text, out value))
            {
                currentObject.Transform.Translate.X = value;
            }
        }

        private void TranslateY_TextChanged(object sender, EventArgs e)
        {
            float value;
            if (float.TryParse(TranslateY.Text, out value))
            {
                currentObject.Transform.Translate.Y = value;
            }
        }

        private void TranslateZ_TextChanged(object sender, EventArgs e)
        {
            float value;
            if (float.TryParse(TranslateZ.Text, out value))
            {
                currentObject.Transform.Translate.Z = value;
            }
        }

        private void RotateX_TextChanged(object sender, EventArgs e)
        {
            float value;
            if (float.TryParse(RotateX.Text, out value))
            {
                currentObject.Transform.Rotate.X = value;
            }
        }

        private void RotateY_TextChanged(object sender, EventArgs e)
        {
            float value;
            if (float.TryParse(RotateY.Text, out value))
            {
                currentObject.Transform.Rotate.Y = value;
            }
        }

        private void RotateZ_TextChanged(object sender, EventArgs e)
        {
            float value;
            if (float.TryParse(RotateZ.Text, out value))
            {
                currentObject.Transform.Rotate.Z = value;
            }
        }

        private void ScaleX_TextChanged(object sender, EventArgs e)
        {
            float value;

            if (float.TryParse(ScaleX.Text, out value))
            {
                currentObject.Transform.Scale.X = value;
            }
        }

        private void ScaleY_TextChanged(object sender, EventArgs e)
        {
            float value;
            if (float.TryParse(ScaleY.Text, out value))
            {
                currentObject.Transform.Scale.Y = value;
            }
        }

        private void ScaleZ_TextChanged(object sender, EventArgs e)
        {
            float value;
            if (float.TryParse(ScaleZ.Text, out value))
            {
                currentObject.Transform.Scale.Z = value;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void ButtonColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                currentObject.Color = colorDialog1.Color;
        }

        private void listObject_MouseClick(object sender, MouseEventArgs e)
        {
            //get mouse position
            int currentIndex = this.listBoxObjects.IndexFromPoint(e.Location);

            //change features
            if (currentIndex != -1)
            {
                //enable features
                EnabledButtonsClick(true);

                //change current object by mouse position
                currentObject = listObjects[currentIndex];

                //change transform boxes
                UpdateTranformBoxes(currentObject);
                
            }
        }

        //load a image file to attands texture on the current object.
        private void ButtomTexture_Click(object sender, EventArgs e)
        {
            if (TextureFile.ShowDialog() == DialogResult.OK)
            {
                if (currentObject != null)
                {
                    currentObject.TexturePath = (TextureFile.FileName);
                    openGLControl1.Invalidate();
                }
            }
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            if (listBoxObjects.Items.Contains(currentObject) && listObjects.Contains(currentObject))
            {
                listBoxObjects.Items.Remove(currentObject);
                listObjects.Remove(currentObject);
                currentObject = null;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
       
        //we don't wan't enabled feature buttons when non object selected.
        private void EnabledButtonsClick(bool mode)
        {
            if (mode)
            {
                TranslateX.Enabled = true;
                TranslateY.Enabled = true;
                TranslateZ.Enabled = true;

                RotateX.Enabled = true;
                RotateY.Enabled = true;
                RotateZ.Enabled = true;

                ScaleX.Enabled = true;
                ScaleY.Enabled = true;
                ScaleZ.Enabled = true;

                ButtonTexture.Enabled = true;
                ButtonColor.Enabled = true;
                ButtonRemove.Enabled = true;
            }
            else
            {
                TranslateX.Enabled = false;
                TranslateY.Enabled = false;
                TranslateZ.Enabled = false;

                RotateX.Enabled = false;
                RotateY.Enabled = false;
                RotateZ.Enabled = false;

                ScaleX.Enabled = false;
                ScaleY.Enabled = false;
                ScaleZ.Enabled = false;

                ButtonTexture.Enabled = false;
                ButtonColor.Enabled = false;
                ButtonRemove.Enabled = false;
            }
        }

        //update transform boxes when we change current object 
        private void UpdateTranformBoxes(Object obj)
        {
            TranslateX.Text = obj.Transform.Translate.X.ToString();
            TranslateY.Text = obj.Transform.Translate.Y.ToString();
            TranslateZ.Text = obj.Transform.Translate.Z.ToString();

            RotateX.Text = obj.Transform.Rotate.X.ToString();
            RotateY.Text = obj.Transform.Rotate.Y.ToString();
            RotateZ.Text = obj.Transform.Rotate.Z.ToString();

            ScaleX.Text = obj.Transform.Scale.X.ToString();
            ScaleY.Text = obj.Transform.Scale.Y.ToString();
            ScaleZ.Text = obj.Transform.Scale.Z.ToString();
        }
        
        //show eye coordinate on the screen
        private void ShowEyeCoord()
        {
            CameraLabelX.Text = Math.Round(camera.EyeCoordX, 2).ToString();
            CameraLabelY.Text = Math.Round(camera.EyeCoordY, 2).ToString();
            CameraLabelZ.Text = Math.Round(camera.EyeCoordZ, 2).ToString();

        }

        private void Instructor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("--------------------*Developer: Chi Cam Hao - HCMUS*------------------- \n \n 1. You need to create 3D objects first. \n 2. Click on that object's name shows on the blue box. \n 3. When your object has the orange outline, the features are yours. \n 4. Use camera: Arrow keys + 'Z' + 'X'. But first, you must 'Cancel' the current object.  \n 5. Believe me, you don't want to translate your objects with any number > 10.\n \n Hope you have a good time!");
        }

        private void ButtonCancle_Click(object sender, EventArgs e)
        {
            if (currentObject != null)
            {
                currentObject = null;
                EnabledButtonsClick(false);
            }
            else
            {
                MessageBox.Show("No object selected.");
            }
        }


    }
}