using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ShoppingCart
/// </summary>
public class ShoppingCart
{
	public ShoppingCart()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    private List<OrderDetails> list = new List<OrderDetails>();

    public List<OrderDetails> List 
    { 
        get { return list; }
        set { list = value; }
    }

    public void AddtoCart(int Id, int quantity)
    {
        foreach (var item in list)
        {
            if (item.albumId.albumId == Id && quantity > 0)
            {
                item.quantity += quantity;
                return;
            }
        }
        AlbumDao dao = new AlbumDao();
        Albums album = dao.SearchId(Id);
        OrderDetails it = new OrderDetails
        {
            albumId = new Albums
            {
                albumId = Id,
            },
            unitprice = album.unitPrice,
            name = album.name,
            image = album.image,
            quantity = quantity,
        };
        list.Add(it);
    }
    public double SubTotal
    {
        get
        {
            double total = 0;
            foreach (var item in list)
            {
                total += item.unitprice * item.quantity;
            }
            return total;
        }
    }
    public void AddOne(int Id) 
    {
        foreach (var item in list) 
        {
            if (item.albumId.albumId == Id)
            {
                item.quantity++;
                return;
            }
        }
        AlbumDao dao = new AlbumDao();
        Albums album = dao.SearchId(Id);
        OrderDetails it = new OrderDetails
        {
            albumId = new Albums
            {
                albumId = Id,
            },
            unitprice = album.unitPrice,
            name = album.name,
            image = album.image,
            quantity = 1,
        };
        list.Add(it);
    }

    public void Remove(int id)
    {
        foreach (var item in list)
        {
            if (item.albumId.albumId == id)
            {
                list.Remove(item);
                return;
            }
        }
    }

    public void SubTract(int Id)
    {
        foreach (var item in list)
        {
            if (item.albumId.albumId == Id)
            {
                item.quantity--;
                if (item.quantity == 0)
                {
                    list.Remove(item);                   
                }
                return;
            }
        }
        AlbumDao dao = new AlbumDao();
        Albums album = dao.SearchId(Id);
        OrderDetails it = new OrderDetails
        {
            albumId = new Albums
            {
                albumId = Id,
            },
            unitprice = album.unitPrice,
            name = album.name,
            image = album.image,
            quantity = 1,
        };
        list.Add(it);
    }


}