import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar"
import { Button } from "@/components/ui/button"
import { Bell, HelpCircle, Search } from 'lucide-react'

export function Header() {
  return (
    <header className="border-b bg-white">
      <div className="flex h-16 items-center gap-x-4 px-4 sm:px-6 lg:px-8">
        <div className="flex flex-1 gap-x-4">
          <div className="relative max-w-md">
            <Search className="absolute left-2.5 top-2.5 h-4 w-4 text-gray-500" />
            <input
              type="search"
              placeholder="Search"
              className="w-full pl-9 border-none bg-gray-50 text-sm focus:ring-0"
            />
          </div>
        </div>
        <div className="flex items-center gap-x-4">
          <Button variant="ghost" size="icon">
            <HelpCircle className="h-5 w-5" />
          </Button>
          <Button variant="ghost" size="icon">
            <Bell className="h-5 w-5" />
          </Button>
          <Avatar>
            <AvatarImage src="/placeholder.svg" />
            <AvatarFallback>JD</AvatarFallback>
          </Avatar>
        </div>
      </div>
    </header>
  )
}

