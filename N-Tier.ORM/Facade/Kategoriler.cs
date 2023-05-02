using N_Tier.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.ORM.Facade
{
    public class Kategoriler
    {
        //Select metodu
        public static DataTable Select()
        {
            SqlDataAdapter adp = new SqlDataAdapter("Select * from Kategoriler", Tools.Baglanti);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        //Insert metodu
        public static bool Insert(Kategori k)
        {
            SqlCommand komut = new SqlCommand();
            //SqlCommand komut = new SqlCommand("UrunEkle",baglanti);//sql de procedure olursa
            //komut.CommandType = CommandType.StoredProcedure;//sql de procedure olursa

            komut.CommandText = "insert Kategoriler (KategoriAdi, Tanimi) values(@adi, @tanimi)";
            komut.Parameters.AddWithValue("@adi", k.KategoriAdi);
            komut.Parameters.AddWithValue("@tanimi", k.Tanimi);
            komut.Connection = Tools.Baglanti;
            return Tools.ExecuteNonQuery(komut);
        }

        //Update metodu

        public static bool Update(Kategori k)
        {
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "update Kategoriler set KategoriAdi=@adi, Tanimi= @tanimi where KategoriID=@id";
            komut.Parameters.AddWithValue("@adi", k.KategoriAdi);
            komut.Parameters.AddWithValue("@tanimi", k.Tanimi);
            komut.Parameters.AddWithValue("@id", k.KategoriID);
            komut.Connection = Tools.Baglanti;
            return Tools.ExecuteNonQuery(komut);
        }

        //Delete metodu
        public static bool Delete(Kategori k)
        {
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "delete from Kategoriler where KategoriID=@id";
            komut.Parameters.AddWithValue("@id", k.KategoriID);
            komut.Connection = Tools.Baglanti;
            return Tools.ExecuteNonQuery(komut);

        }
    }
}
