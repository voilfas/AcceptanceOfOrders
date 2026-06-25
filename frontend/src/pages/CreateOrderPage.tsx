import {useState} from "react";
import {createOrder} from "../api/ordersApi.ts";
import axios from "axios";
import { Link } from "react-router-dom";
import "../styles/CreateOrderPage.css";

function CreateOrderPage() {

    const [senderCity, setSenderCity] = useState("");
    const [senderAddress, setSenderAddress] = useState("");

    const [receiverCity, setReceiverCity] = useState("");
    const [receiverAddress, setReceiverAddress] = useState("");

    const [weight, setWeight] = useState<number | "">("");
    const [pickUpDate, setPickUpDate] = useState("");

    const [error, setError] = useState("");
    const [createdOrderNumber, setCreatedOrderNumber] = useState("");
    

    async function handleSubmit(
        e: React.FormEvent
    ) {
        e.preventDefault();

        try {
            const orderNumber = await createOrder({
                senderCity,
                senderAddress,
                receiverCity,
                receiverAddress,
                weight,
                pickUpDate
            });

            setCreatedOrderNumber(orderNumber);
            setSenderCity("");
            setSenderAddress("");

            setReceiverCity("");
            setReceiverAddress("");

            setWeight(0);
            setPickUpDate("");
            setError("");
        }
        catch (error: unknown) {
            if (axios.isAxiosError(error)) {
                setError(
                    error.response?.data?.message ??
                    "Не все поля заполнены"
                );
            }
        }
    }

    return (
        <div className="orders-page">
            <div className="form-card">
                <h1 className="form-title">
                    Create Order
                </h1>

                {createdOrderNumber && (
                    <div className="success-message">
                        <h3>Order created successfully</h3>

                        <p>
                            Generated Number:
                            <strong> {createdOrderNumber}</strong>
                        </p>
                    </div>
                )}

                {error && (
                    <div className="error-message">
                        {error}
                    </div>
                )}
            
            <form onSubmit={handleSubmit}>

                <div className="section">

                    <h3 className="section-title">
                        Sender Information
                    </h3>

                    <div className="row">

                        <div className="field">
                            <label>City</label>

                            <input
                                value={senderCity}
                                onChange={(e) =>
                                    setSenderCity(e.target.value)}
                            />
                        </div>

                        <div className="field">
                            <label>Address</label>

                            <input
                                value={senderAddress}
                                onChange={(e) =>
                                    setSenderAddress(e.target.value)}
                            />
                        </div>

                    </div>

                </div>

                <div className="section">

                    <h3 className="section-title">
                        Receiver Information
                    </h3>

                    <div className="row">

                        <div className="field">
                            <label>City</label>

                            <input
                                value={receiverCity}
                                onChange={(e) =>
                                    setReceiverCity(e.target.value)}
                            />
                        </div>

                        <div className="field">
                            <label>Address</label>

                            <input
                                value={receiverAddress}
                                onChange={(e) =>
                                    setReceiverAddress(e.target.value)}
                            />
                        </div>

                    </div>

                </div>

                <div className="single-field">
                    <label>Weight (kg)</label>

                    <input
                        type="number"
                        value={weight}
                        onChange={(e) =>
                            setWeight(Number(e.target.value))}
                    />
                </div>

                <div className="single-field">
                    <label>Pickup Date</label>

                    <input
                        type="datetime-local"
                        value={pickUpDate}
                        onChange={(e) =>
                            setPickUpDate(e.target.value)}
                    />
                </div>

                <button
                    type="submit"
                    className="submit-button"
                >
                    Create Order
                </button>

            </form>

                <Link
                    to="/"
                    className="back-link"
                >
                    ← Back to Orders
                </Link>

            </div>
        </div>
    );
}

export default CreateOrderPage;