using SharpGL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static ObjectBuilder.ObjectBuilder.Constants;

namespace ObjectBuilder
{
    public partial class ObjectBuiler : Form
    {
        readonly Camera _camera = new Camera(CameraUnit);
        Object _currentObject = new Object();
        readonly List<Object> _objects = new List<Object>();

        public ObjectBuiler()
        {
            InitializeComponent();

            //we don't wan't enabled feature buttons when non object selected.
            SetInteractableButtons(false);
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
            _camera.UpdateLookAt(gl);

            //set current matrix mode to transform view space to clip space, we use perspective mode
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.Perspective(70, openGLControl1.Width * 1f / openGLControl1.Height, 1, 50);

            //set viewport to stranform clip space to screen space.
            gl.Viewport(
                0, 0,
                openGLControl1.Width,
                openGLControl1.Height);

            _camera.Zoom(CameraZoom.In);
        }

        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {
            OpenGL gl = openGLControl1.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            //set current matrix mode to transform local space to world space.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);

            //transform the projection matrix.
            _camera.UpdateLookAt(gl);

            // Load the identity.
            gl.LoadIdentity();

            //transform the projection matrix
            _camera.UpdateLookAt(gl);

            //create grid map
            GridMap gridMap = new GridMap(WorldUnit);

            // Draw a grid map with parameter 2 is the size.
            gridMap.DrawGridMap(gl, 10 * WorldUnit);

            //drawing all objects.
            foreach (Object obj in _objects)
            {
                //update ischoose to select a fit outline
                if (obj == _currentObject)
                    obj.IsChoosed = true;
                else
                    obj.IsChoosed = false;

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
                    _camera.Zoom(CameraZoom.In);
                    break;
                case Keys.X:
                    _camera.Zoom(CameraZoom.Out);
                    break;
                case Keys.Left:
                    _camera.Rotate(CameraRotate.Left);
                    break;
                case Keys.Right:
                    _camera.Rotate(CameraRotate.Right);
                    break;
                case Keys.Up:
                    _camera.Rotate(CameraRotate.Up);
                    break;
                case Keys.Down:
                    _camera.Rotate(CameraRotate.Down);
                    break;

                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Creating object methods
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void CreateCube_CLick(object sender, EventArgs e)
        {
            Cube cube = new Cube();

            _objects.Add(cube);
            listBoxObjects.Items.Add(cube);
        }
        private void CreatePrism_CLick(object sender, EventArgs e)
        {
            Prism prism = new Prism();

            _objects.Add(prism);
            listBoxObjects.Items.Add(prism);
        }
        private void CreatePyramid_Click(object sender, EventArgs e)
        {
            Pyramid pyramid = new Pyramid();

            _objects.Add(pyramid);
            listBoxObjects.Items.Add(pyramid);
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Update transform methods
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void TranslateX_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(TranslateX.Text, out var value))
            {
                _currentObject.Transform.Translate.X = value;
            }
        }

        private void TranslateY_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(TranslateY.Text, out var value))
            {
                _currentObject.Transform.Translate.Y = value;
            }
        }

        private void TranslateZ_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(TranslateZ.Text, out var value))
            {
                _currentObject.Transform.Translate.Z = value;
            }
        }

        private void RotateX_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(RotateX.Text, out var value))
            {
                _currentObject.Transform.Rotate.X = value;
            }
        }

        private void RotateY_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(RotateY.Text, out var value))
            {
                _currentObject.Transform.Rotate.Y = value;
            }
        }

        private void RotateZ_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(RotateZ.Text, out var value))
            {
                _currentObject.Transform.Rotate.Z = value;
            }
        }

        private void ScaleX_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(ScaleX.Text, out var value))
            {
                _currentObject.Transform.Scale.X = value;
            }
        }

        private void ScaleY_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(ScaleY.Text, out var value))
            {
                _currentObject.Transform.Scale.Y = value;
            }
        }

        private void ScaleZ_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(ScaleZ.Text, out var value))
            {
                _currentObject.Transform.Scale.Z = value;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // UI input operations
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void ButtonColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                _currentObject.Color = colorDialog1.Color;
            }
        }

        private void listObject_MouseClick(object sender, MouseEventArgs e)
        {
            //get mouse position
            int currentIndex = this.listBoxObjects.IndexFromPoint(e.Location);

            //change features
            if (currentIndex != -1)
            {
                //enable features
                SetInteractableButtons(true);

                //change current object by mouse position
                _currentObject = _objects[currentIndex];

                //change transform boxes
                UpdateTranformBoxes(_currentObject);
                
            }
        }

        //load a image file to attands texture on the current object.
        private void ButtomTexture_Click(object sender, EventArgs e)
        {
            if (TextureFile.ShowDialog() == DialogResult.OK)
            {
                if (_currentObject != null)
                {
                    _currentObject.TexturePath = TextureFile.FileName;
                    openGLControl1.Invalidate();
                }
            }
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            if (listBoxObjects.Items.Contains(_currentObject) && _objects.Contains(_currentObject))
            {
                listBoxObjects.Items.Remove(_currentObject);
                _objects.Remove(_currentObject);
                _currentObject = null;
            }
        }

        private void Instructor_Click(object sender, EventArgs e)
        {
            MessageBox.Show(InstructionText);
        }

        private void ButtonCancle_Click(object sender, EventArgs e)
        {
            if (_objects != null)
            {
                _currentObject = null;
                SetInteractableButtons(false);
            }
            else
            {
                MessageBox.Show("No object selected.");
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // UI interactions
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // we don't wan't enabled feature buttons when non object selected.
        private void SetInteractableButtons(bool interactable)
        {
            TranslateX.Enabled = interactable;
            TranslateY.Enabled = interactable;
            TranslateZ.Enabled = interactable;

            RotateX.Enabled = interactable;
            RotateY.Enabled = interactable;
            RotateZ.Enabled = interactable;

            ScaleX.Enabled = interactable;
            ScaleY.Enabled = interactable;
            ScaleZ.Enabled = interactable;

            ButtonTexture.Enabled = interactable;
            ButtonColor.Enabled = interactable;
            ButtonRemove.Enabled = interactable;            
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
            CameraLabelX.Text = Math.Round(_camera.EyeCoord.X, 2).ToString();
            CameraLabelY.Text = Math.Round(_camera.EyeCoord.Y, 2).ToString();
            CameraLabelZ.Text = Math.Round(_camera.EyeCoord.Z, 2).ToString();

        }
    }
}