import type {Order} from "../types/order.ts";
import {useEffect, useState} from "react";
import {getOrders} from "../api/ordersApi.ts";
import {Link, useNavigate} from "react-router-dom";

function OrdersPage() {
    const navigate = useNavigate();
    
    const [orders, setOrders] = useState<Order[]>([]);
    
    useEffect(() => {
        loadOrders();
    }, []);
    
    async function loadOrders() {
        const data = await getOrders();
        setOrders(data);
    }
    
    
    return (
        <div style={{ padding: "20px" }}>
            <h1>Orders List</h1>

            <Link to="/orders/create">
                <button>Create Order</button>
            </Link>

            <table
                border={1}
                cellPadding={10}
                style={{
                    marginTop: "20px",
                    width: "100%",
                    borderCollapse: "collapse"
                }}
            >
                <thead>
                <tr>
                    <th>Order Number</th>
                    <th>Sender City</th>
                    <th>Receiver City</th>
                    <th>Weight</th>
                </tr>
                </thead>

                <tbody>
                {orders.map(order => (
                    <tr
                        key={order.orderId}
                        onClick={() => navigate(`/orders/${order.orderId}`)}
                        style={{ cursor: "pointer" }}
                    >
                        <td>{order.orderNumber}</td>
                        <td>{order.senderCity}</td>
                        <td>{order.receiverCity}</td>
                        <td>{order.weight}</td>
                    </tr>
                ))}
                </tbody>
            </table>
        </div>
    );
}

export default OrdersPage;