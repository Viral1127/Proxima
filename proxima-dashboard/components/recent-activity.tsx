import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"

export function RecentActivity() {
  const activities = [
    { user: "John Doe", action: "created a new project", time: "2 hours ago" },
    { user: "Jane Smith", action: "completed a task", time: "4 hours ago" },
    { user: "Mike Johnson", action: "added a new user", time: "1 day ago" },
    { user: "Sarah Williams", action: "updated project settings", time: "2 days ago" },
  ]

  return (
    <Card>
      <CardHeader>
        <CardTitle>Recent Activity</CardTitle>
      </CardHeader>
      <CardContent>
        <ul className="space-y-4">
          {activities.map((activity, index) => (
            <li key={index} className="flex items-start space-x-2">
              <div className="bg-blue-500 rounded-full w-2 h-2 mt-2"></div>
              <div>
                <p className="text-sm font-medium">{activity.user} {activity.action}</p>
                <p className="text-xs text-gray-500">{activity.time}</p>
              </div>
            </li>
          ))}
        </ul>
      </CardContent>
    </Card>
  )
}

