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
        internal static ProductResponse GetProductByID(int id)
        {
            ProductResponse productResponse = new ProductResponse();
            Product product = new Product();
            product = ProductData.GetProduct(id);
            if (product != null)
            {
                productResponse.statusCode = 00;
                productResponse.status = "Successful";
                productResponse.product = product;
            }
            else
            {
                productResponse.statusCode = 01;
                productResponse.status = "UnSuccessful";
                productResponse.product = null;
            }
            return productResponse;
        }

        internal static ProductListResponse GetAllProduct(string status)
        {
            ProductListResponse productList = new ProductListResponse();
            List<Product> product = new List<Product>();
            if (status.ToLower() == "all") {
                product = ProductData.AllProductList();
                if (product != null)
                {
                    productList.statusCode = 00;
                    productList.status = "Successful";
                    productList.product = product;

                }
                else
                {
                    productList.statusCode = 01;
                    productList.status = "Unsuccessful";
                    productList.product = null;

                }
                return productList;
            }
            

            product = ProductData.ProductList(status);
            if (product != null) {
                productList.statusCode=00;
                productList.status="Successful";
                productList.product = product;

            }
            else
            {
                productList.statusCode = 01;
                productList.status = "Unsuccessful";
                productList.product = null;

            }

            return productList;
        }

        internal static ProductResponse DeleteProduct(int id)
        {
            ProductResponse productResponse = new ProductResponse();

            string result = string.Empty;
            result = ProductData.DeleteProduct(id);
            if (result =="00")
            {
                productResponse.statusCode = 00;
                productResponse.status = "Successful";
                productResponse.product = null;
            }
            else
            {
                productResponse.statusCode = 01;
                productResponse.status = "UnSuccessful";
                productResponse.product = null;
            }

            return productResponse;
        }

        internal static ProductResponse EditProduct(ProductEditRequest value )
        {
            ProductResponse productResponse = new ProductResponse();
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


                    productResponse.statusCode = 00;
                    productResponse.status = "Successful";
                    productResponse.product = product;
                }else
                {
                    productResponse.statusCode = 01;
                    productResponse.status = "UnSuccessful, not found";
                    productResponse.product = null;
                }
            }
            else
            {
                productResponse.statusCode = 01;
                productResponse.status = "UnSuccessful, not found";
                productResponse.product = null;
            }

            return productResponse;
        }
        internal static ProductResponse CreateProduct(ProductRequest value)
        {
            ProductResponse productResponse = new ProductResponse();

            string result = string.Empty;
            result = ProductData.CreateProduct(value);
            if (result =="00")
            {
                productResponse.statusCode = 00;
                productResponse.status = "Successful";
                 var prod = ProductData.GetProductUsingName(value.ProductName);
                if (prod.ProductID != 0)
                {
                    productResponse.product = prod;
                }
                else
                {
                    productResponse.product = null;
                }
            }
            else
            {
                productResponse.statusCode = 01;
                productResponse.status = "UnSuccessful";
                productResponse.product = null;
            }

            return productResponse; 
        }
    }
}
        