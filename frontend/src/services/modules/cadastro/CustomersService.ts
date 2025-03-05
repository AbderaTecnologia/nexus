import { CustomerRequest, CustomersList } from "@/@types/register";
import ApiService from "@/services/ApiService";

class CustomersService {
  public static async getCustomers() {
    const response = await ApiService.fetchDataWithAxios<CustomersList>({
      url: "/cadastro/cliente/list",
      method: "get",
    });
    return response.result;
  }

  public static async postCustomer(data: CustomerRequest) {
    const response = await ApiService.fetchDataWithAxios({
      url: "/cadastro/cliente/",
      method: "post",
      data: data
    });
  }
}

export async function apiGetCustomersList() {
  return CustomersService.getCustomers();
}

export async function apiPostCustomer(data: CustomerRequest) {
  return CustomersService.postCustomer(data);
}

export async function apiGetCustomersList2<T, U extends Record<string, unknown>>(
  params: U,
)
{
  return ApiService.fetchDataWithAxios<T>(
    {
      url: '/cadastro/cliente/list',
      method: 'get'
    }
  )
}