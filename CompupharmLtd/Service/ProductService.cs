using CompupharmLtd.Data;
using CompupharmLtd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompupharmLtd.Service
{
    public class ProductService
    {
        internal static Response GetProductByID(int id)
        {
            Response productResponse = new Response();
            Product product = new Product();
            product = ProductData.GetProduct(id);
            if (product != null)
            {
                product.ProductImage= BlobService.GetBlob(product.ProductName);    
                productResponse.statusCode = 00;
                productResponse.status = "Successful";
                productResponse.data = product;
            }
            else
            {
                productResponse.statusCode = 01;
                productResponse.status = "UnSuccessful";
                productResponse.data = null;
            }
            return productResponse;
        }

        internal static Response GetAllProduct(string status)
        {
            Response productList = new Response();
            List<Product> product = new List<Product>();
            if (status.ToLower() == "all") {
                product = ProductData.AllProductList();
                if (product != null)
                {
                    foreach(Product prod in product)
                    {
                       prod.ProductImage =  BlobService.GetBlob(prod.ProductName);
                        
                    }
                    productList.statusCode = 00;
                    productList.status = "Successful";
                    productList.data = product;

                }
                else
                {
                    productList.statusCode = 01;
                    productList.status = "Unsuccessful";
                    productList.data = null;

                }
                return productList;
            }
            

            product = ProductData.ProductList(status);
            if (product != null) {

                foreach (Product prod in product)
                {
                    prod.ProductImage = BlobService.GetBlob(prod.ProductName);

                }
                productList.statusCode=00;
                productList.status="Successful";
                productList.data = product;

            }
            else
            {
                productList.statusCode = 01;
                productList.status = "Unsuccessful";
                productList.data = null;

            }

            return productList;
        }

        internal static Response DeleteProduct(int id)
        {
            Response productResponse = new Response();
            Product prod = ProductData.GetProduct(id);
            string result = string.Empty;
            result = ProductData.DeleteProduct(id);
            if (result =="00")
            {
                BlobService.Delete(prod.ProductName);
                productResponse.statusCode = 00;
                productResponse.status = "Successful";
                productResponse.data = null;
            }
            else
            {
                productResponse.statusCode = 01;
                productResponse.status = "UnSuccessful";
                productResponse.data = null;
            }

            return productResponse;
        }

        internal static Response EditProduct(ProductEditRequest value )
        {
            Response productResponse = new Response();
            string result = string.Empty;
            Product product = new Product();
            product = ProductData.GetProduct(value.ProductID);
                //ProductData.EditProduct(id);
            if (product != null)
            {
                Product productEdit = new Product()
                {

                    ProductID = value.ProductID,
                    ProductName = value.ProductName,
                    ProductShortDescription = value.ProductShortDescription,
                    ProductfullDescription = value.ProductfullDescription,
                    ProductStatus = value.ProductStatus,
                    ProductPrice = value.ProductPrice,
                    ProductQuantity = value.ProductQuantity,
                    ProductImage = value.ProductImage,
                    ProductRestriction = value.ProductRestriction,
                };
                result =ProductData.EditProduct(productEdit);
                if (result == "00") {

                    BlobService.Upload(productEdit.ProductName, productEdit.ProductImage);
                    productResponse.statusCode = 00;
                    productResponse.status = "Successful";
                    productResponse.data = product;
                }else
                {
                    productResponse.statusCode = 01;
                    productResponse.status = "UnSuccessful, not found";
                    productResponse.data = null;
                }
            }
            else
            {
                productResponse.statusCode = 01;
                productResponse.status = "UnSuccessful, not found";
                productResponse.data = null;
            }

            return productResponse;
        }
        internal static Response CreateProduct(ProductRequest value)
        {
            Response productResponse = new Response();

            string result = string.Empty;
            result = ProductData.CreateProduct(value);
            if (result =="00")
            {
                if(!BlobService.Upload(value.ProductName, value.ProductImage))
                {
                    productResponse.statusCode = 02;
                    productResponse.status = "Successfully created, couldnt upload image";
                }
                productResponse.statusCode = 00;
                productResponse.status = "Successful";
                 var prod = ProductData.GetProductUsingName(value.ProductName);
                if (prod.ProductID != 0)
                {
                  prod.ProductImage=  BlobService.GetBlob(value.ProductName);

                    productResponse.data = prod;
                }
                else     
                {
                    productResponse.data = null;
                }
            }
            else
            {
                productResponse.statusCode = 01;
                productResponse.status = "UnSuccessful";
                productResponse.data = null;
            }

            return productResponse; 
        }

     

        internal static bool ValidateProductRequest(ProductRequest product)
        {
            bool isValid = false;

            if (!string.IsNullOrEmpty(product.ProductName))
            {
                isValid = true;
            }
            return isValid;
        }
    }
}
        