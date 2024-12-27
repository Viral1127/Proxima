import Image from 'next/image'
import { Button } from "@/components/ui/button"
import Link from 'next/link'

export default function NotFound() {
  return (
    <div className="flex flex-col items-center justify-center min-h-screen bg-gray-50 px-4">
      <div className="text-center">
        <Image
          src="/404-error.svg"
          alt="404 Not Found"
          width={300}
          height={300}
          className="mb-8"
        />
        <h1 className="text-4xl font-bold text-gray-900 mb-4">404 - Page Not Found</h1>
        <p className="text-xl text-gray-600 mb-8">Oops! The page you're looking for doesn't exist.</p>
        <Button asChild>
          <Link href="/">
            Go back to homepage
          </Link>
        </Button>
      </div>
    </div>
  )
}

