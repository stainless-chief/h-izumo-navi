require "mini_magick"

if Rails.env.development?
  ::MiniMagick.configure { |config|
    config.cli = :imagemagick
    config.cli_prefix = %w[docker exec imagemagick]
  }
end