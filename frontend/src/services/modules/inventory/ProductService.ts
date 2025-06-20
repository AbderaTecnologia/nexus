import ApiService from "@/services/ApiService";

export async function getProducts<T>() {
    return ApiService.fetchDataWithAxios<T>({
        url: "/products",
        method: "GET"
    });
}

export async function getProductById<T>(id: string) {
    return ApiService.fetchDataWithAxios<T>({
        url: `/products/${id}`,
        method: "GET"
    });
}

export async function createProduct<T>(data: {
    name: string;
    description: string;
    barCode: string;
    unitOfMeasure: string;
    price: number;
    costPrice: number;
}) {
    return ApiService.fetchDataWithAxios<T>({
        url: "/products",
        method: "POST",
        data
    });
}