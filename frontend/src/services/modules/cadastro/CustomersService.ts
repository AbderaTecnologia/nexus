import { CustomersList } from "@/@types/register";
import ApiService from "@/services/ApiService";

class CustomersService {
  public static async getCustomers() {
    const response = await ApiService.fetchDataWithAxios<CustomersList>({
      url: "/cadastro/cliente/list",
      method: "get",
    });
    return response.result;
  }
}

export async function apiGetCustomersList() {
  return CustomersService.getCustomers();
}