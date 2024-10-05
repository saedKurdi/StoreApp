﻿namespace StoreApp.ProductService.Entities;
public class Product
{
    // public properties : 
    public int Id { get; set; }
    public string ? Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity {  get; set; }
    public string ? ImageUrl { get; set; }
}
