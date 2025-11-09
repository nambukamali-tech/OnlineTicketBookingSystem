import React from "react";
import { createBrowserRouter, RouterProvider} from "react-router-dom";
import Home from "./pages/home";
import Login from "./pages/Login";
import Signup from "./pages/Signup";
// Create router using new v7 API
const router = createBrowserRouter([
  { path: "/", element: <Home /> },
  {path: "/Login", element: <Login />},
  {path: "/Signup", element: <Signup />},
]);
function App()
{
 return <RouterProvider router={router} />;
}
export default App;




