export interface Iproduct {
    productId: number;
    productName: string;
    description: string;
    price: number;
    productCode: string;
    manufactureDate: string;
    imageUrl: string;
    starRating: number;
    productColor?: string; // optional
}
