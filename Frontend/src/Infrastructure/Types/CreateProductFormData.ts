export type  CreateProductFormData = {
    productName: string;
    productDescription: string;
    categories: string[];
    metaTags: string;
    price: string |number;
    enableStockTracking: boolean;
    stock: string |number;
    images: File[];
    storeId:number;
  }