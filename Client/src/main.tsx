import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import { router } from "@/router/Routes.tsx";
import "./index.css";
import { RouterProvider } from "react-router";

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <RouterProvider router={router} />
  </StrictMode>
);
