# Store App Microservices Solution

This repository contains a microservices-based store application solution in Visual Studio Code. The solution features seven microservices, enabling users to add products with details such as name, quantity, price, and image. The image is uploaded to Cloudinary using the `ImageServiceAPI`. The app also supports barcode reading and generation, with barcodes being stored in the database if they do not already exist.

## Microservices Overview

This solution includes the following microservices:

1. **ApiGateway**  
   - Acts as the central entry point for client requests, routing them to the correct microservice.
   
2. **BarcodeServiceAPI**  
   - Handles reading, validation, and creation of barcodes. If a barcode is not found, it is saved to the database and generated based on user input on subsequent requests.
   
3. **ImageServiceAPI**  
   - Manages image uploads to Cloudinary when users add products with images.
   
4. **LogServiceAPI**  
   - A centralized logging service for monitoring and debugging the system.
   
5. **ProductServiceAPI**  
   - Manages the product catalog, including adding new products (name, quantity, price, and image). Works with the `ImageServiceAPI` for image handling and the `BarcodeServiceAPI` for barcode generation.
   
6. **SearchServiceAPI**  
   - Allows users to search for products in the system.
   
7. **WebUI**  
   - The user interface that allows users to interact with the system, add products, and search for items.

## Features

- **Add Products:** Users can add products by providing a name, quantity, price, and an image.
- **Image Upload:** The `ImageServiceAPI` uploads product images to Cloudinary.
- **Barcode Handling:** If a barcode doesn't exist, the `BarcodeServiceAPI` saves it to the database and generates it on future requests.
- **Logging:** All actions are logged by the `LogServiceAPI` for debugging and monitoring.
- **Search Functionality:** Users can search products using the `SearchServiceAPI`.

## Getting Started

### Prerequisites

Before running this solution, ensure you have the following:

- **Visual Studio Code**
- **.NET Core SDK**
- **Docker** (optional, for containerizing services)
- **Cloudinary API Account** for image storage

### Running the Solution

1. **Clone the repository** to your local machine:
   ```bash
   git clone https://github.com/your-username/store-app-microservices.git
