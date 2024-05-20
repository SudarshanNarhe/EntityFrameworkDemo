using EntityFrameworkDemo.Data;

namespace EntityFrameworkDemo.Models
{
    public class ProductDAL
    {
        ApplicationDbContext db;

        public ProductDAL(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<Product> GetProducts() 
        { 
            return db.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            var product = db.Products.FirstOrDefault(p=>p.ProductId == id);
            return product;
        }

        public int AddProduct(Product product)
        {
            int result = 0;
            db.Products.Add(product);
            result = db.SaveChanges();
            return result;
        }
        public int UpdateProduct(Product product)
        {
            int result = 0;
            var prd = db.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if(prd != null)
            {
                prd.ProductName = product.ProductName;
                prd.Price = product.Price;
                result = db.SaveChanges();
            }
            return result;
        }

        public int DeleteProduct(int id)
        {
            int result = 0;
            var prd = db.Products.FirstOrDefault(p => p.ProductId == id);
            if (prd != null)
            {
               db.Products.Remove(prd);
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
