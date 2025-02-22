import useAccount from "@/lib/hooks/useAccount";
import { useEffect } from "react";
import { useNavigate } from "react-router";

export default function Logout() {
  const { logoutUser, currentUser } = useAccount();
  const navigate = useNavigate();
  useEffect(() => {
    if (currentUser) {
      logoutUser.mutate();
    } else {
      navigate("/auth/login");
    }
  }, []);
  return (
    <div className="flex flex-col gap-2 items-center">
      <h1 className="text-2xl font-bold">Logging out...</h1>
    </div>
  );
}
