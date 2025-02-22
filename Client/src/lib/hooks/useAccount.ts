import agent from "@/lib/api/agent";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { LoginSchema, RegisterSchema } from "../schemas/loginSchema";
import { useLocation, useNavigate } from "react-router";

export default function useAccount() {
  const queryClient = useQueryClient();
  const navigate = useNavigate();
  const location = useLocation();

  const loginUser = useMutation({
    mutationFn: async (loginSchema: LoginSchema) => {
      await agent.post("/login?useCookies=true", loginSchema);
    },
    onSuccess: () => {
      queryClient.invalidateQueries({
        queryKey: ["user"],
      });
    },
  });

  const registerUser = useMutation({
    mutationFn: async (registerSchema: RegisterSchema) => {
      await agent.post("/account/register", registerSchema);
      return {
        email: registerSchema.email,
        password: registerSchema.password,
      };
    },
    onSuccess: async (credentials) => {
      await loginUser.mutateAsync(credentials);
      queryClient.invalidateQueries({
        queryKey: ["user"],
      });
    },
  });

  const logoutUser = useMutation({
    mutationFn: async () => {
      await agent.post("/account/logout");
    },
    onSuccess: () => {
      queryClient.invalidateQueries({
        queryKey: ["user"],
      });
      navigate("/auth/login");
    },
  });

  const { data: currentUser, isLoading: loadingUser } = useQuery({
    queryKey: ["user"],
    queryFn: async () => {
      const result = await agent.get<User>("/account/user");
      return result.data;
    },
    enabled:
      !queryClient.getQueryData(["user"]) &&
      location.pathname !== "/auth/login" &&
      location.pathname !== "/auth/signup" &&
      location.pathname !== "/auth/forgot-password",
  });

  return {
    currentUser,
    loadingUser,
    loginUser,
    registerUser,
    logoutUser,
  };
}
