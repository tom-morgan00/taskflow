import { clsx, type ClassValue } from "clsx";
import { twMerge } from "tailwind-merge";
import { DateArg, format } from "date-fns";

export function cn(...inputs: ClassValue[]) {
  return twMerge(clsx(inputs));
}

export function formatDate(
  date: DateArg<Date>,
  dateFormat: string = "dd/MM/yyyy"
) {
  return format(date, dateFormat);
}
