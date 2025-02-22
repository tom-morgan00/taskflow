import { z } from "zod";

export const formSchema = z.object({
  name: z.string().min(1, "Name is required"),
  description: z.string().optional(),
  status: z.enum(["ToDo", "InProgress", "Done"]),
  dueDate: z.date().optional().nullable(),
  workspaceId: z.string().min(1, "Workspace is required"),
});

export type FormSchema = z.infer<typeof formSchema>;
