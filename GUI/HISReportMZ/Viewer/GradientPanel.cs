using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public partial class GradientPanel : Panel
    {
        Color _gradientStartColor;
        Color _gradientEndColor;
        Image _floatingImage;
        int _imageXOffset;
        int _imageYOffset;
        int _angle;
        float _horizontalFillPercent;
        float _verticalFillPercent;
        bool _flip;
        public GradientPanel()
        {
            _gradientStartColor = Color.White;
            _gradientEndColor = Color.Gray;
            _floatingImage = null;
            _imageXOffset = 0;
            _imageYOffset = 0;
            _angle = 90;
            _horizontalFillPercent = 100;
            _verticalFillPercent = 100;
            _flip = false;
            this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            this.DoubleBuffered = true;
        }
        public Color GradientStartColor
        {
            get
            {
                return _gradientStartColor;
            }
            set
            {
                _gradientStartColor = value;
                this.Invalidate();
            }
        }

        public Color GradientEndColor
        {
            get
            {
                return _gradientEndColor;
            }
            set
            {
                _gradientEndColor = value;
                this.Invalidate();
            }
        }
        public Image FloatingImage
        {
            get
            {
                return _floatingImage;
            }
            set
            {
                _floatingImage = value;
                Bitmap b = FloatingImage as Bitmap;
                if (b != null)
                {
                    b.MakeTransparent(Color.White);
                }
                this.Invalidate();
            }
        }

        public int imageXOffset
        {
            get
            {
                return _imageXOffset;
            }
            set
            {
                _imageXOffset = value;
                this.Invalidate();
            }
        }

        public int imageYOffset
        {
            get
            {
                return _imageYOffset;
            }
            set
            {
                _imageYOffset = value;
                this.Invalidate();
            }
        }

        public int GradientAngle
        {
            get
            {
                return _angle;
            }
            set
            {
                _angle = value;
                this.Invalidate();
            }
        }

        public float HorizontalFillPercent
        {
            get
            {
                return _horizontalFillPercent;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _horizontalFillPercent = value;
                    this.Invalidate();
                }
            }
        }
        public float VerticalFillPercent
        {
            get
            {
                return _verticalFillPercent;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _verticalFillPercent = value;
                    this.Invalidate();
                }
            }
        }
        public bool Flip
        {
            get
            {
                return _flip;
            }
            set
            {
                _flip = value;
                this.Invalidate();
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            try
            {
                Rectangle _fillRectangle;
                Rectangle clientRect = this.ClientRectangle;

                int _newWidth = (int)((float)clientRect.Width * (_horizontalFillPercent / 100));
                int _newHeight = (int)((float)clientRect.Height * (_verticalFillPercent / 100));
                int _newAngle = _angle;
                int _newX = clientRect.X;
                int _newY = clientRect.Y;
                if (_horizontalFillPercent < 100 || _verticalFillPercent < 100)
                {
                    using (Brush br = new SolidBrush(this.BackColor))
                    {
                        e.Graphics.FillRectangle(br, clientRect.X, clientRect.Y, clientRect.Width, clientRect.Height);
                    }
                }
                if (_flip)
                {
                    _newX += (clientRect.Width - _newWidth);
                    _newY += (clientRect.Height - _newHeight);
                    _newAngle = (_angle + 180) % 360;
                    _fillRectangle = new Rectangle(new Point(_newX, _newY), new Size(_newWidth - 1, _newHeight));
                }
                else
                    _fillRectangle = new Rectangle(clientRect.Location, new Size(_newWidth, _newHeight));

                using (Brush b = new LinearGradientBrush(_fillRectangle, _gradientStartColor, _gradientEndColor, _newAngle))
                {
                    e.Graphics.FillRectangle(b, _newX, _newY, _newWidth, _newHeight);
                }
                if (_floatingImage != null)
                {
                    e.Graphics.DrawImage(_floatingImage, new Point((this.Width - (_floatingImage.Width + _imageXOffset)), (this.Height - (_floatingImage.Height + _imageYOffset))));
                }
            }
            catch { }
        }
    }
}