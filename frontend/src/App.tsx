import OrdersPage from "./pages/OrdersPage.tsx";
import './App.css'
import {BrowserRouter, Route, Routes} from "react-router-dom";
import CreateOrderPage from "./pages/CreateOrderPage.tsx";
import OrderDetailsPage from "./pages/OrderDetailsPage.tsx";

function App(){
  return (
      <BrowserRouter>
          <Routes>
              <Route path="/" element={<OrdersPage />} />

              <Route
                  path="/orders/create"
                  element={<CreateOrderPage />}
              />

              <Route
                  path="/orders/:id"
                  element={<OrderDetailsPage />}
              />
          </Routes>
      </BrowserRouter>
  );
}

export default App
