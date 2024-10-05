// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function addProduct() {
    let response = getUploadedImage();
    response.then((d) => {
        const name = document.getElementById("product").value;
        const price = document.getElementById("price").value;
        const quantity = document.getElementById("quantity").value;

        let obj = {
            "id": 0,
            "name": name,
            "price": Number(price),
            "quantity": Number(quantity),
            "imageUrl":d,
        }
        console.log(obj);

        $.ajax({
            url: "https://localhost:22955/p",
            method: "POST",
            data: JSON.stringify(obj),
            contentType: "application/json;charset=utf-8",
            dataType:"json",
            success: (response) => {
                console.log(response);
                location.href = "https://localhost:7083";
            },
            error: () => {
                console.log("Request failed !");
            }
        });
    });
}

function getUploadedImage() {
    let fileInput = document.getElementById("MyImage");

    if (fileInput.files.length === 0) {
        return "https://thumbs.dreamstime.com/b/new-product-vector-stamp-label-element-isolated-color-editable-35730435.jpg";
    }

    let file = fileInput.files[0];
    var formData = new FormData();
    formData.append("file", file);

    return $.ajax({
        url: "https://localhost:22955/i",
        method: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: (response) => {
            console.log(response);
            return response;
        },
        error: () => {
            console.log("Request failed !");
        }
    });
}

let products = [];

function CallGetAll() {
    $.ajax({
        url: "https://localhost:22955/p",
        method: "GET",
        success: (data) => {
            products = data;
            let content = "";
            for (let i = 0; i < products.length; i++) {
                let item = `
                <div class='card' style='width:18rem;'>
                    <img class='card-img-top' style='height:350px;' src='${data[i].imageUrl}' />
                    <div class='card-body'>
                        <h5 class='card-title'>${data[i].name}</h5>
                        <p class='card-text'>$${data[i].price}</p>
                        <a class='btn btn-primary' onclick='SelectProduct(${data[i].id})' >Select Product</a>
                    </div>
                </div>`;
                content += item;
            }
            $("#products").html(content);
        }
    });
}

CallGetAll();

let selectedProduct;
function SelectProduct(productId) {
    $("#productId").val(productId);
    selectedProduct = products.find(p => p.id == productId);
    console.log(selectedProduct);
}

function GetBarcode() {
    const volume = $("#volumeId").val();
    const obj = {
        "productId": selectedProduct.id,
        "volume": volume,
        price: selectedProduct.price,
        "productName": selectedProduct.name,
    };
    console.log(obj);
    $.ajax({
        url: "https://localhost:22955/b",
        method: "POST",
        data: JSON.stringify(obj),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: (response) => {
            $("#result").html(response.data);
        },
        error: (error) => {
            console.log(error);
        }
    });
}

let element = document.getElementById("p-info");

function Search() {
    const value = $("#searchInput").val();
    if (String(value).trim() === "") {
        alert("Please use barcode scanner");
    } else {
        $.ajax({
            url: `https://localhost:22955/s/${value}`,
            method: "GET",
            success: (data) => {
                let content = `
                <div>
                  <img src='${data.imageUrl}' style='width:100px;height:100px;'/>  
                  <h1>Name : ${data.producName}</h1>
                  <div>
                    <h5>Code : ${data.code}</h5>
                    <h4>Total Price : $${data.totalPrice}</h4>
                  </div>
                </div>
                `;
                element.innerHTMLs += content;
            }
        });
    }
}