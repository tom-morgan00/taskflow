import AuthLayout from "@/layout/AuthLayout";
import { Outlet } from "react-router";

export default function AuthPage() {
  return (
    <AuthLayout>
      <Outlet />
    </AuthLayout>
  );
}
