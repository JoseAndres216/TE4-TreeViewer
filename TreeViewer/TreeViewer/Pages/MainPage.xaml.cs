using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewer.DataStructures.BinaryTree;
using TreeViewer.Pages;
using Xamarin.Forms;

namespace TreeViewer
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private BinaryTree tree;
        public MainPage()
        {
            InitializeComponent();
            tree = new BinaryTree();
        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            if(Int32.Parse(txbNumber.Text) > int.MinValue && Int32.Parse(txbNumber.Text) < int.MaxValue)
            {
                tree.Add(Int32.Parse(txbNumber.Text));
                await DisplayAlert("Congrats", "El numero se agrego al arbol", "OK");
            }
            else
            {
                await DisplayAlert("Ups", "Algo salio mal", ":(");
            }
            
        }

        private void btnPRE_Clicked(object sender, EventArgs e)
        {
            tree.PREOrderList.Clear();
            tree.PREOrder(tree.Root);
            this.Navigation.PushModalAsync(new PathViewer("PRE", this.tree));
        }

        private void btnIN_Clicked(object sender, EventArgs e)
        {
            tree.INOrderList.Clear();
            tree.INOrder(tree.Root);
            this.Navigation.PushModalAsync(new PathViewer("IN", this.tree));
        }

        private void btnPOST_Clicked(object sender, EventArgs e)
        {
            tree.POSTOrderList.Clear();
            tree.POSTOrder(tree.Root);
            this.Navigation.PushModalAsync(new PathViewer("POST", this.tree));
        }
    }
}
