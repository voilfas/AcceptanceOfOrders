import axios from "axios";
import type {Order} from "../types/order.ts";

export const api = axios.create({
    baseURL: "http://localhost:8080/api"
});

export async function getOrders(): Promise<Order[]>
{
    const responce = await api.get("/orders");
    
    return responce.data;
}
