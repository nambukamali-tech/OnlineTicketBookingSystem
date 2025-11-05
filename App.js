import React from "react";
import { createBrowserRouter, RouterProvider} from "react-router-dom";
import Home from "./pages/Home";
// Create router using new v7 API
const router = createBrowserRouter([
  { path: "/", element: <Home /> },
]);
function App()
{
 return <RouterProvider router={router} />;
}
export default App;


