using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeViewer.DataStructures.BinaryTree;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TreeViewer.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PathViewer : ContentPage
    {
        public PathViewer(string order, BinaryTree tree)
        {
            InitializeComponent();
            if(order == "PRE")
            {
                ListView.ItemsSource = tree.PREOrderList;
                this.PopUpPRE();
            }else if(order == "IN")
            {
                ListView.ItemsSource = tree.INOrderList;
                this.PopUpIN();
            }
            else
            {
                ListView.ItemsSource = tree.POSTOrderList;
                this.PopUpPOST();
            }

            if (tree.Root == null)
            {
                lblRoot.Text = "El arbol no existe";
            }
            else
            {
                lblRoot.Text = "Raiz: " + tree.Root.Data.ToString();
            }
        }

        public async void PopUpPRE()
        {
            await DisplayAlert("INFO", "En un recorrido en PREorden se muestra primero la raiz, " +
                "luego el subarbol izquierdo y finalmente el subarbol derecho", "OK");
        }

        public async void PopUpIN()
        {
            await DisplayAlert("INFO", "En un recorrido en INorden se muestra primero el subarbol izquierdo, " +
                "luego la raiz y finalmente el subarbol derecho", "OK");
        }

        public async void PopUpPOST()
        {
            await DisplayAlert("INFO", "En un recorrido en POSTorden se muestra primero el subarbol izquierdo, " +
                "luego el subarbol derecho y finalmente la raiz", "OK");
        }
    }
}