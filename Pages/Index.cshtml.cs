using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;



namespace webpageC_.Pages;

public class IndexModel : PageModel
{
   
    
    //[BindProperty]
    public Reference reference { get; set; }
    public int state { get; set; }
   
    public string Message { get; set; }
    // [TempData]
    public string Message2 { get; set; }
   
    //[BindProperty]
    public Store store { get; set; }
    public void OnGet()
    {
    
    }
    public  void  OnPost(string reference2)   //IActionResult

    {
    
      SearchEan(reference2);
        
    }


public  void SearchEan(string reference2){
        
        
   
     //string reference = textBox1.Text;
    string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=td2q2019;";
    // Seleccionar todo
    string query = "SELECT distinct europroducts.reference as ref, europroducts.libelleproduit AS description, europroducts.prixeuroht as prix , oemnumbers.legacyArticleId as legacy, articleean.eancode as ean ";
     query += "FROM `eurocrossref` INNER JOIN europroducts ON europroducts.reference=eurocrossref.REF_EURO inner join oemnumbers on oemnumbers.articleNumber=eurocrossref.REF_FRN ";
     query += "inner join articleean on articleean.legacyArticleId=oemnumbers.legacyArticleId WHERE REF_EURO='"+reference2+"'";
             

    MySqlConnection databaseConnection = new MySqlConnection(connectionString);
    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
    commandDatabase.CommandTimeout = 60;
    MySqlDataReader reader;

    try
    {
        databaseConnection.Open();
        reader = commandDatabase.ExecuteReader();
         

        // Si se encontraron datos
        if (reader.HasRows)
        {
            reference = new Reference();
            while (reader.Read())
            {
                reference.refe =  reader.GetString(0);   
                reference.description = reader.GetString(1);
                reference.price = float. Parse(reader.GetString(2));
                reference.legacy = reader.GetString(3);
                reference.ean = reader.GetString(4);



                float f1 = float. Parse(reader.GetString(2));
             
            Message="REFERENCE: "+reference.refe+" "+"DESCRIPTION: "+reference.description+"\n"+"PRICE: "+f1+"€\n";
            
                    Task<string> task = SearchStores(reference.ean, f1);
                    task.Wait();
                    Message2 = task.Result;

                 


               
            }
        }
        else
        {
            Console.WriteLine("No se encontro nada");
            Message=("No se encontro nada");
        }

        databaseConnection.Close();
    }
    catch (Exception ex)
    {
        if (ex.Message is not null){
        Console.WriteLine(ex.Message);
        }
    }
   




    }

public  async Task <string> SearchStores(string ean, float price){

 //string ean=textBox1.Text;
 //string Message3="";

        string api_key = "l1sb4dr7rnng4ftxp41smz54soubg2";
            //Define your baseUrl
            
            string baseUrl = "https://api.barcodelookup.com/v3/products?barcode="+ean+"&formatted=y&key="+api_key;
            //Have your using statements within a try/catch block
            try
            {
                //We will now define your HttpClient with your first using statement which will implements a IDisposable interface.
                using (HttpClient client = new HttpClient())
                {
                    
                    
                    //In the next using statement you will initiate the Get Request, use the await keyword so it will execute the using statement in order.
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                         
                        //Then get the content from the response in the next using statement, then within it you will get the data, and convert it to a c# object.
                        using (HttpContent content = res.Content)
                        {
                            //Now assign your content to your data variable, by converting into a string using the await keyword.
                            
                             
                            var data = await content.ReadAsStringAsync();
                            //If the data isn't null return log convert the data using newtonsoft JObject Parse class method on the data.
                            if (content != null)
                            {
                               
                                //Now log your data object in the console
                              JToken jToken = JObject.Parse(data)["products"][0]["stores"];
                              int length = jToken.Count();
                             

                             store = new Store();
                             
                              for (int i = 0; i < length; i++)
                              {
                               
                                 
                               
                               JToken jToken2 = JObject.Parse(data)["products"][0]["stores"][i];
                               store.country = jToken2["country"].ToString();
                                 store.name = jToken2["name"].ToString();
                                    store.price = jToken2["price"].ToString();
                            //Message2+=("Information found in "+store.name+" in "+store.country+" for "+store.price+" €");
                               Message2+=jToken2["name"].ToString()+" "+jToken2["country"].ToString()+" "+jToken2["price"].ToString()+" € </br>";

                             
                              }
                              //Console.WriteLine(Message2); 
                              
                            }
                            else
                            {
                                Console.WriteLine("NO Data----------");
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                //Console.WriteLine("Exception Hit------------");
               // Console.WriteLine(exception);
            }

        
       
        Task<string> task = Task.FromResult(Message2);
        return task.Result;

}








 public class Reference
    {
       public string? refe { get; set; }
       public string? ean { get; set; }
       public string? description { get; set; }
       public float  price { get; set; }
       public string? legacy { get; set; }
    }
public class Store
{
    public string? name { get; set; }
    public string? country { get; set; }
    public string? price { get; set; }
}


}




   




