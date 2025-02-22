type Task = {
  id: string;
  name: string;
  description?: string;
  status: "ToDo" | "InProgress" | "Done";
  dueDate?: Date;
  createdAt: string;
  workspaceId: string;
};

type Workspace = {
  id: string;
  name: string;
  createdAt: string;
  tasks: Task[];
};

type User = {
  id: string;
  displayName: string;
  email: string;
  imageUrl?: string;
  bio?: string;
  phoneNumber?: string;
  phoneNumberConfirmed: boolean;
  emailConfirmed: boolean;
};
