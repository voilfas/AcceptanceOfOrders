import {Link, useParams} from "react-router-dom";
import {getOrderById} from "../api/ordersApi.ts";
import {useEffect, useState} from "react";
import type {OrderDetails} from "../types/orderDetails.ts";

function OrderDetailsPage() {
    const { id } = useParams();

    const [order, setOrder] =
        useState<OrderDetails | null>(null);

    useEffect(() => {
        if (id) {
            loadOrder(id);
        }
    }, [id]);

    async function loadOrder(orderId: string) {
        const data = await getOrderById(orderId);

        setOrder(data);
    }

    if (!order) {
        return <h2>Loading...</h2>;
    }

    return (
        <div style={{ padding: "20px" }}>

            <h1>Order Details</h1>
            
            <p>
                <strong>Order Number:</strong>{" "}
                {order.orderNumber}
            </p>

            <p>
                <strong>Sender City:</strong>{" "}
                {order.senderCity}
            </p>

            <p>
                <strong>Sender Address:</strong>{" "}
                {order.senderAddress}
            </p>

            <p>
                <strong>Receiver City:</strong>{" "}
                {order.receiverCity}
            </p>

            <p>
                <strong>Receiver Address:</strong>{" "}
                {order.receiverAddress}
            </p>

            <p>
                <strong>Weight:</strong>{" "}
                {order.weight} kg
            </p>

            <p>
                <strong>Pickup Date:</strong>{" "}
                {new Date(order.pickUpDate)
                    .toLocaleString()}
            </p>

            <p>
                <strong>Created At:</strong>{" "}
                {new Date(order.createdAt)
                    .toLocaleString()}
            </p>

            <p>
                <strong>Order ID:</strong>{" "}
                {order.id}
            </p>

            <Link to="/" style={{ marginTop: "30px", display: "inline-block" }}>
                ← Back to Orders
            </Link>
        </div>
    );
}

export default OrderDetailsPage;