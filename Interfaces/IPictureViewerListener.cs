using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeVault.Interfaces
{
    public interface IPictureViewerListener
    {
        /// <summary>
        /// This method is used to unselect others when selected
        /// </summary>
        /// <param name="newSelectedPictureName"></param>
        void PictureViewerSelectionChanged(PictureViewer pictureViewer);
    }
}
