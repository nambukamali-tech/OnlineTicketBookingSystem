import React from "react";
import { BrowserRouter , Routes , Route} from "react-router-dom";
import login from "./pages/login";
import signup from "./pages/signup";
import home from "./pages/home";
function App()
{
  return(

    <BrowserRouter>
    <Routes>
      <Route path="/" element={<login/>}/>
      <Route path="/signup" element={<signup/>}/>
      <Route path="/home" element={<home/>}/>
    </Routes>
    </BrowserRouter>
  );
}
export default App;

